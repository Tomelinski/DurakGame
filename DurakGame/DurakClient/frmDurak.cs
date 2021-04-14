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
using PlayerLibrary;

namespace DurakClient
{
    public partial class frmDurak : Form
    {

        private static Card trumpCard;
        public static Card TrumpCard
        {
            get { return trumpCard; }
            set
            {
                trumpCard = value;
                Card.TrumpSuit = value.Suit;

            }
        }

        /// <summary>
        /// The amount, in points, that CardBox controls are enlarged when hovered over. 
        /// </summary>
        private const int POP = 15;

        /// <summary>
        /// The regular size of a CardBox control
        /// </summary>
        static private Size regularSize = new Size(76, 110);

        // Durak Game Static variables
        //-Holds Game Information
        public static Card AttackCard { get; set; }     // Holds the Current Attack Card in the Round
        public static Card DefendCard { get; set; }     // Holds the Current Defend Card in the Round
        public static Cards PlayedCards { get; set; }   // A List of cards currently in play for a Round
        public static Deck GameDeck { get; set; }       // The Deck object being used in this instance
        public static Player[] Players { get; set; }    // An array of Players that are apart of this instance
        private static int AttackingPlayer { get; set; }    // The index of the currnetly attacking Player in the Player array
        private static bool RoundOver { get; set; }         // A boolean to let the program know when a round has ended.
        private static bool DefendingPlayerSkip { get; set; }   // A boolean to let the program know that if a skipping player is a defender.


        // Deck Settings
        Deck deck;
        Cards collection = new Cards();
        Cards addCard = new Cards();



        public frmDurak(int deckSize, int playerNum)
        {
            InitializeComponent();

            //******* TESTING ONLY *******//


            //******* TESTING ONLY *******//

        }

        private void pbDeck_Click(object sender, EventArgs e)
        {

        }

        #region FORM EVENTS
        void frmDurak_Load(object sender, EventArgs e)
        {
            ResetGameVariables(pbDeck, pbTrump, pnlOponentHand, pnlPlayerHand, lblPlayerStatus);
        }
        #endregion

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

                    // Remove the Event Handler for this card
                    cardBox.Click -= CardBox_Click;
                    cardBox.MouseEnter -= CardBox_MouseEnter;
                    cardBox.MouseLeave -= CardBox_MouseLeave;
                    cardBox.Enabled = false;

                    // Remove the card from the home panel
                    pnlPlayerHand.Controls.Remove(cardBox);
                    // Add the control to the play panel
                    pnlPlayArea.Controls.Add(cardBox);

                    Players[1].DrawCard(cardBox.PlayingCard);
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

        public static void ResetGameVariables(PictureBox pbDeck, PictureBox pbTrump, Panel opponentHand, Panel playerHand, Label playerStatus)
        {
            // Reference Form Objects


            // Create the Players
            Players = new Player[2];
            //Players[0] = new Player("Calvin");
            //Players[1] = new Player("Tom");
            Players[0] = new AI("AI1");
            Players[1] = new Player("AI2");


            // Create and shuffle a deck
            GameDeck = new Deck(36);
            GameDeck.Shuffle();

            // Set the trump card
            TrumpCard = GameDeck.DrawNextCard();
            TrumpCard.FaceUp = true;
            //TrumpCard.FaceUp = true;
            pbDeck.Image = (new Card()).GetCardImage();
            pbTrump.Image = (TrumpCard.GetCardImage());
            pbTrump.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);

            // Fill the players hand for the start of the match
            FillPlayerHands(Players);
            PopulateCardBoxControls(opponentHand, playerHand);
            // Set the Attcking Player
            AttackingPlayer = GetInitialAttacker();
            Players[AttackingPlayer].PlayerIsAttacking = true;
            playerStatus.Text = Players[1].PlayerIsAttacking ? "You are Attacking!" : "You Are Defending!";
            ResortPlayers();

            // Reset the PlayedCards List
            PlayedCards = new Cards();

            // Set RoundOver as False
            RoundOver = false;

        }

        public static void FillPlayerHands(Player[] players)
        {
            foreach (Player player in players)
            {
                player.FillHand(GameDeck);
                player.PlayerHand.Sort();
            }

        }

        public static int GetInitialAttacker()
        {
            int playerIndex = 0;    // Default to first Player if anything goes wrong
            Cards lowestCards = new Cards();

            foreach (Player player in Players)
            {
                lowestCards.Add(player.PlayerHand[0]);
            }

            lowestCards.Sort();

            foreach (Player player in Players)
            {
                if (lowestCards[0] == player.PlayerHand[0])
                    playerIndex = Array.IndexOf(Players, player);

            }

            return playerIndex;

        }

        public static void ResortPlayers()
        {
            while (!Players[0].PlayerIsAttacking)
            {
                Player tempPlayer = Players[0];

                for (int i = 0; i < Players.Count(); i++)
                {
                    if (i != Players.Count() - 1)
                    {
                        Players[i] = Players[i + 1];
                    }
                    else
                    {
                        Players[i] = tempPlayer;
                    }
                }

            }
            AttackingPlayer = 0;
        }

        public static void RotateAttacker()
        {
            Players[AttackingPlayer].PlayerIsAttacking = false;

            if (AttackingPlayer == Players.Count() - 1)
            {
                AttackingPlayer = 0;
            }
            else
            {
                AttackingPlayer++;
            }

            Players[AttackingPlayer].PlayerIsAttacking = true;

            //TODO ALTER THE PLAYER STATUS LABEL
            //playerStatus.Text = Players[1].PlayerIsAttacking ? "You are Attacking!" : "You Are Defending!";

        }

        public static void PopulateCardBoxControls(Panel opponentHand, Panel playerHand)
        {
            opponentHand.Controls.Clear();
            playerHand.Controls.Clear();
            foreach (Player player in Players)
            {
                foreach (Card card in player.PlayerHand)
                {
                    // Check which player we're on
                    if (player.GetType().ToString() == "PlayerLibrary.AI")
                    {
                        card.FaceUp = true;
                        opponentHand.Controls.Add(new CardBox(card));

                    }
                    else
                    {
                        card.FaceUp = true;
                        CardBox cardBox = new CardBox(card);                

                        playerHand.Controls.Add(cardBox);
                    }
                }

            }


        }


        private void HandPanel_ControlAdded(object sender, ControlEventArgs e)
        {
            if (sender == pnlPlayerHand)
            {
                foreach (CardBox cardBox in pnlPlayerHand.Controls)
                {
                    // Wire the Click Event
                    cardBox.Click += CardBox_Click;
                    // Wire the CardBox_MouseEnter event for Visual Effects
                    cardBox.MouseEnter += CardBox_MouseEnter;
                    // Wire CardBox_MouseLeave for the regular Visual Effects
                    cardBox.MouseLeave += CardBox_MouseLeave;
                }

                RealignCards(pnlPlayerHand);
            }

            else
                RealignCards(pnlOponentHand);

        }

        private void PlayAreaPanel_ControlAdded(object sender, ControlEventArgs e)
        {
            // Store the Information
            CardBox addedCardBox = pnlPlayArea.Controls[pnlPlayArea.Controls.Count - 1] as CardBox;
            Card addedCard = addedCardBox.PlayingCard;
            PlayedCards.Add(addedCard);

            foreach (Player player in Players)
            {
                // Check Player Type, so that we know which Panel to work with
                if (player.GetType().ToString() == "PlayerLibrary.AI")      // Player is AI
                {
                    foreach (CardBox cardBox in pnlPlayArea.Controls)
                    {

                        if (player.PlayerIsAttacking == true)
                        {

                        }
                        else
                        {

                        }
                    }

                }
                else    // Player is Human
                {
                    // Loop through each Cardbox in Play

                        // Check if the Player is attacking
                        if (player.PlayerIsAttacking == true)                   
                        {
                            foreach (CardBox cardBox in pnlPlayArea.Controls)
                            {
                                foreach (CardBox playerCardBox in pnlPlayerHand.Controls)
                                {
                                    if (cardBox.PlayingCard.Rank != playerCardBox.PlayingCard.Rank)
                                    {
                                        playerCardBox.Enabled = false;
                                    }
                                    else
                                        playerCardBox.Enabled = true;
                                }
                            }   
                            
                            
                        }
                        // Else If the Player is Defending
                        else
                        {
                            foreach (CardBox playerCardBox in pnlPlayerHand.Controls)
                            {
                                if ((addedCard.Suit == playerCardBox.PlayingCard.Suit || TrumpCard.Suit == playerCardBox.PlayingCard.Suit) &&
                                     addedCard < playerCardBox.PlayingCard)
                                {
                                    playerCardBox.Enabled = true;
                                }
                                else
                                    playerCardBox.Enabled = false;
                            }
                        
                    }

                }
            }
            

            
        }


        // TODO: SWITCH THIS TO A METHOD ****************************************************************************
        private void PlayAreaPanel_ControlRemoved(object sender, ControlEventArgs e)
        {
            foreach (CardBox cardBox in pnlOponentHand.Controls)
            {
                cardBox.Enabled = true;
            }
            foreach (CardBox cardBox in pnlPlayerHand.Controls)
            {
                cardBox.Enabled = true;
            }
        }
    }
}

       