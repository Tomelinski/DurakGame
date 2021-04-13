using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyCardBox;
using CardLibrary;

namespace DurakClient
{
    public partial class frmDurak : Form
    {

        /// <summary>
        /// The amount, in points, that CardBox controls are enlarged when hovered over. 
        /// </summary>
        private const int POP = 15;

        /// <summary>
        /// The regular size of a CardBox control
        /// </summary>
        static private Size regularSize = new Size(76, 110);


        // Deck Settings
        Deck deck;
        Cards collection = new Cards();
        Cards addCard = new Cards();


        // Storing the Deck and Card
        CardBox deckBox;
        CardBox trumpCard;
        public frmDurak(int deckSize, int playerNum)
        {
            InitializeComponent();

            //******* TESTING ONLY *******//
            pbDeck.Image = (new Card()).GetCardImage();


            deckSize = 20;
            deck = new Deck(deckSize);
            deck.Shuffle();

            Card trumpCard = deck.DrawNextCard();
            trumpCard.FaceUp = true;
            pbTrump.Image = (trumpCard.GetCardImage());
            pbTrump.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            //******* TESTING ONLY *******//

        }

        private void pbDeck_Click(object sender, EventArgs e)
        {
            // Create a new card
            Card card = new Card();

            // Draw a card from the card dealer. If it worked...
            if (deck.HasCards())
            {
                card = deck.DrawNextCard();
                card.FaceUp = true;
                // Create a new CardBox control based on the card drawn
                CardBox cardBox = new CardBox(card);

                cardBox.Click += CardBox_Click; // Wire CardBox_Click


                // wire CardBox_MouseEnter for the "POP" visual effect
                cardBox.MouseEnter += CardBox_MouseEnter;
                // wire CardBox_MouseLeave for the regular visual effect
                cardBox.MouseLeave += CardBox_MouseLeave;
                // Add the new control to the appropriate panel
                pnlPlayerHand.Controls.Add(cardBox);
                // Realign the controls in the panel so they appear correctly.
                FormatPlayArea(pnlPlayerHand);
            }
        }

        #region CARD BOX EVENT HANDLERS

        /// <summary>
        ///  CardBox controls grow in size when the mouse is over it.
        /// </summary>
        void CardBox_MouseEnter(object sender, EventArgs e)
        {
            // Convert sender to a CardBox
            CardBox cardBox = sender as CardBox;

            // If the conversion worked
            if (cardBox != null)
            {
                // Enlarge the card for visual effect
                cardBox.Size = new Size(regularSize.Width + POP, regularSize.Height + POP);
                // move the card to the top edge of the panel.
                cardBox.Top = 0;

            }
        }
        /// <summary>
        /// CardBox control shrinks to regular size when the mouse leaves.
        /// </summary>
        void CardBox_MouseLeave(object sender, EventArgs e)
        {
            // Convert sender to a CardBox
            CardBox cardBox = sender as CardBox;
            // If the conversion worked
            if (cardBox != null)
            {
                // resize the card back to regular size
                cardBox.Size = new Size(regularSize.Width, regularSize.Height);
                // move the card down to accommodate for the smaller size.
                cardBox.Top = POP;
            }
        }

        /// <summary>
        /// When a CardBox is clicked, move to the opposite panel.
        /// </summary>
        void CardBox_Click(object sender, EventArgs e)
        {
            // Convert sender to a CardBox
            CardBox cardBox = sender as CardBox;
            // If the conversion worked
            if (cardBox != null)
            {
                // if the card is in the home panel...
                if (cardBox.Parent == pnlPlayerHand)
                {
                    // Remove the card from the home panel
                    pnlPlayerHand.Controls.Remove(cardBox);
                    // Add the control to the play panel
                    pnlPlayArea.Controls.Add(cardBox);
                }
                // otherwise...
                else
                {
                    // Remove the card from the play panel
                    pnlPlayArea.Controls.Remove(cardBox);
                    // Add the control to the home panel
                    pnlPlayerHand.Controls.Add(cardBox);
                }
                // Realign the cards 
                RealignCards(pnlPlayerHand);
                RealignCards(pnlPlayArea);
            }

        }

        #endregion

        #region HELPER METHODS

        /// <summary>
        /// Repositions the cards in a panel so that they are evenly distributed in the area available.
        /// </summary>
        /// <param name="panelHand"></param>
        private void RealignCards(Panel panelHand)
        {
            // Determine the number of cards/controls in the panel.
            int cardCount = panelHand.Controls.Count;

            // If there are any cards in the panel
            if (cardCount > 0)
            {
                // Determine how wide one card/control is.
                int cardWidth = (panelHand.Controls[0].Width);

                // Determine where the left-hand edge of a card/control placed 
                // in the middle of the panel should be  
                int startPoint = ((panelHand.Width - cardWidth) / 2);

                // An offset for the remaining cards
                int offset = 0;

                // If there are more than one cards/controls in the panel
                if (cardCount > 1)
                {
                    // Determine what the offset should be for each card based on the 
                    // space available and the number of card/controls
                    offset = (panelHand.Width - cardWidth - 2 * POP) / (cardCount - 1);

                    // If the offset is bigger than the card/control width, i.e. there is lots of room, 
                    // set the offset to the card width. The cards/controls will not overlap at all.
                    if (offset > cardWidth)
                        offset = cardWidth;

                    // Determine width of all the cards/controls 
                    int totalCardsWidth = (cardCount - 1) * offset + cardWidth;
                    // Set the start point to where the left-hand edge of the "first" card should be.
                    startPoint = (panelHand.Width - totalCardsWidth) / 2;
                }
                // Aligning the cards: Note that I align them in reserve order from how they
                // are stored in the controls collection. This is so that cards on the left 
                // appear underneath cards to the right. This allows the user to see the rank
                // and suit more easily.

                // Align the "first" card (which is the last control in the collection)
                panelHand.Controls[cardCount - 1].Top = POP;
                System.Diagnostics.Debug.Write(panelHand.Controls[cardCount - 1].Top.ToString() + "\n");
                panelHand.Controls[cardCount - 1].Left = startPoint;

                // for each of the remaining controls, in reverse order.
                for (int index = cardCount - 2; index >= 0; index--)
                {
                    // Align the current card
                    panelHand.Controls[index].Top = POP;
                    panelHand.Controls[index].Left = panelHand.Controls[index + 1].Left + offset;
                }
            }
        }

        

        private void FormatPlayArea(Panel panelHand)
        {

            // Determine the number of cards/controls in the panel.
            int cardCount = panelHand.Controls.Count;

            // If there are any cards in the panel
            if (cardCount > 0)
            {
                // Determine how wide one card/control is.
                int cardWidth = (panelHand.Controls[0].Width);

                // Determine where the left-hand edge of a card/control placed 
                // in the middle of the panel should be  
                int startPoint = ((panelHand.Width - cardWidth) / 6);

                // An offset for the remaining cards
                int offset = 0;

                // If there are more than one cards/controls in the panel
                if (cardCount > 1)
                {
                    // Determine what the offset should be for each card based on the 
                    // space available and the number of card/controls
                    offset = (cardWidth) + 30;

                    // If the offset is bigger than the card/control width, i.e. there is lots of room, 
                    // set the offset to the card width. The cards/controls will not overlap at all.
                    if (cardCount % 2 != 0)
                        offset = (cardWidth / 2);

                    // Determine width of all the cards/controls 
                        int totalCardsWidth = (cardCount - 1) * offset + cardWidth;
                    // Set the start point to where the left-hand edge of the "first" card should be.
                    startPoint = (totalCardsWidth);
                }
                // Aligning the cards: Note that I align them in reserve order from how they
                // are stored in the controls collection. This is so that cards on the left 
                // appear underneath cards to the right. This allows the user to see the rank
                // and suit more easily.

                // Align the "first" card (which is the last control in the collection)
                panelHand.Controls[cardCount - 1].Top = POP;
                System.Diagnostics.Debug.Write(panelHand.Controls[cardCount - 1].Top.ToString() + "\n");
                panelHand.Controls[cardCount - 1].Left = startPoint;

                // for each of the remaining controls, in reverse order.
                for (int index = cardCount - 2; index >= 0; index--)
                {
                    // Align the current card
                    panelHand.Controls[index].Top = POP;
                    panelHand.Controls[index].Left = panelHand.Controls[index + 1].Left + offset;
                }
            
            }
        }



            /// <summary>
            /// Clears the panels and reloads the deck.
            /// </summary>
            void Reset()
        {
            // Clear the panels
            pnlPlayerHand.Controls.Clear();
            pnlOponentHand.Controls.Clear();
            pnlPlayArea.Controls.Clear();

        }
        #endregion

    }
}

       