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
        private static int DeckSize { get; set; }
        private static int PlayerNum { get; set; }
        private static string PlayerName { get; set; }
        //-Holds Game Information
        public static Card AttackCard { get; set; }     // Holds the Current Attack Card in the Round
        public static Card DefendCard { get; set; }     // Holds the Current Defend Card in the Round
        public static Cards PlayedCards { get; set; }   // A List of cards currently in play for a Round
        public static Deck GameDeck { get; set; }       // The Deck object being used in this instance
        public static Player[] Players { get; set; }    // An array of Players that are apart of this instance
        private static int AttackingPlayer { get; set; }    // The index of the currnetly attacking Player in the Player array
        private static bool RoundOver { get; set; }         // A boolean to let the program know when a round has ended.
        private static bool DefendingPlayerSkip { get; set; }   // A boolean to let the program know that if a skipping player is a defender.
        private static bool repop { get; set; }
        private static int PlayerIndex
        {
            get
            {
                if (Players[0].GetType().ToString() == "PlayerLibrary.Player")
                    return 0;

                return 1;

            }
        }
        private static int AiIndex
        {
            get
            {
                if (Players[0].GetType().ToString() == "PlayerLibrary.AI")
                    return 0;

                return 1;

            }
        }


        // Deck Settings
        Deck deck;
        Cards collection = new Cards();
        Cards addCard = new Cards();



        public frmDurak( int deckSize, int playerNum, string playerName)
        {
            InitializeComponent();

            DeckSize = deckSize;
            PlayerNum = playerNum;
            PlayerName = playerName;

        }

        private void pbDeck_Click(object sender, EventArgs e)
        {

        }

        #region FORM EVENTS
        void frmDurak_Load(object sender, EventArgs e)
        {
            ResetGameVariables(pbDeck, pbTrump, pnlOpponentHand, pnlPlayerHand, lblPlayerStatus);
            GameDeck.LastCardDrawn += GameDeck_OutOfCards;
            PopulateCardBoxControls(pnlOpponentHand, pnlPlayerHand);
            if (Players[AiIndex].PlayerIsAttacking)
                Ai_AttacksFirst(this, new EventArgs());
                
        }

        private void Ai_AttacksFirst(object sender, EventArgs e)
        {
            int cardIndex = 0;

            cardIndex = (Players[AiIndex] as AI).GetAttackingCardIndex(GameDeck, TrumpCard, PlayedCards);

            cardIndex -= 1;

            // Write the Event
            (pnlOpponentHand.Controls[cardIndex] as CardBox).Click += CardBox_Click;

                // Perform a Click
            (pnlOpponentHand.Controls[cardIndex] as CardBox).PerformClick();
          
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
            CardBox newBox = new CardBox(cardBox.PlayingCard);

            // If the conversion worked
            if (newBox != null)
            {
                // Common Work

                //cardBox.Click -= CardBox_Click;
                newBox.Enabled = false;

                // Remove Click Event and disable the cardBox
                //AttackCard = cardBox.PlayingCard;
                PlayedCards.Add(newBox.PlayingCard);

                // Add the control to the play panel
                pnlPlayArea.Controls.Add(newBox);



                // Player Specific
                // if the card is in the home panel...
                if (cardBox.Parent.Name.ToString() == "pnlPlayerHand")
                {
                    // Remove the Event Handler for this card
                    //cardBox.MouseEnter -= CardBox_MouseEnter;
                    //cardBox.MouseLeave -= CardBox_MouseLeave;

                    

                    // Draw the Card from the Hand
                    if (Players[PlayerIndex].PlayerIsAttacking)
                        AttackCard = Players[PlayerIndex].PlayCard(newBox.PlayingCard);
                    else
                        DefendCard = Players[PlayerIndex].PlayCard(newBox.PlayingCard);

                    // Remove the card from the home panel
                    pnlPlayerHand.Controls.Remove(cardBox);

                }
                else if (cardBox.Parent.Name.ToString() == "pnlOpponentHand")
                {
                    //Players[AiIndex].PlayerHandOutOfCards += wesdfsdfsdf
                    // Draw the Card from the Hand
                    if (Players[AiIndex].PlayerIsAttacking)
                        AttackCard = Players[AiIndex].PlayCard(cardBox.PlayingCard);
                    else
                        DefendCard = Players[AiIndex].PlayCard(cardBox.PlayingCard);


                    // Remove the card from the home panel
                    pnlOpponentHand.Controls.Remove(cardBox);
                }

                //lblDebug.Text = cardBox.Parent.Name.ToString();

                

                
                
                // Realign the cards 
                RealignCards(pnlPlayerHand);
                RealignCards(pnlPlayArea);
                RealignCards(pnlOpponentHand);

            }

        }

        private void HandPanel_ControlAdded(object sender, ControlEventArgs e)
        {
            if (sender == pnlPlayerHand)     
                RealignCards(pnlPlayerHand);
            else
                RealignCards(pnlOpponentHand);
            

 

        }
        private void PlayerHandPanel_ControlRemoved(object sender, ControlEventArgs e)
        {
            if (!repop)
            {

                int cardIndex = 0;

                if (Players[AiIndex].PlayerIsAttacking)
                {
                    cardIndex = (Players[AiIndex] as AI).GetAttackingCardIndex(GameDeck, TrumpCard, PlayedCards);
                }
                else
                {
                    cardIndex = (Players[AiIndex] as AI).GetDefendingCardIndex(GameDeck, TrumpCard, PlayedCards, AttackCard);
                }

                // Adjust Card Index

                if (cardIndex != 0)
                {
                    cardIndex -= 1;

                    // Write the Event
                    (pnlOpponentHand.Controls[cardIndex] as CardBox).Click += CardBox_Click;

                    // Perform a Click
                    (pnlOpponentHand.Controls[cardIndex] as CardBox).PerformClick();
                }
                else
                {
                    //if player skips turn while defending
                    if (!Players[AiIndex].PlayerIsAttacking)
                    {
                        //picks up all previously played cards
                        foreach (Card card in PlayedCards)
                        {
                            Players[AiIndex].DrawCard(card);
                        }

                    }
                    //player skips turns while attacking
                    else
                    {
                        //rotate attackers array, to allow AI to play first
                        RotateAttacker();
                        ResortPlayers();
                    }

                    //Disable the AI from playing(calling PlayerHandPanel_ControlRemoved event) during repopulation
                    repop = true;

                    //Destroy PlayedCards variable
                    PlayedCards = new Cards();
                    //Fill all players hands
                    FillPlayerHands(Players);
                    //Repopulate and resort all player controlls
                    PopulateCardBoxControls(pnlOpponentHand, pnlPlayerHand);
                    //Remove card from play area
                    pnlPlayArea.Controls.Clear();

                    repop = false;

                    // Realign the cards 
                    RealignCards(pnlPlayerHand);
                    RealignCards(pnlOpponentHand);

                   /* //check if AI plays need to play first card
                    if (!Players[PlayerIndex].PlayerIsAttacking)
                        Ai_AttacksFirst(this, new EventArgs());*/

                    lblPlayerStatus.Text = Players[PlayerIndex].PlayerIsAttacking ? "You are Attacking!" : "You Are Defending!";
                }
            }
        }
        private void PlayAreaPanel_ControlAdded(object sender, ControlEventArgs e)
        {
            // Store the Information
            CardBox addedCardBox = pnlPlayArea.Controls[pnlPlayArea.Controls.Count - 1] as CardBox;
            Card addedCard = addedCardBox.PlayingCard;

            // Loop through each Cardbox in Play

            foreach (CardBox playerCardBox in pnlPlayerHand.Controls)
            {
                playerCardBox.Enabled = false;
            }

            // Check if the Player is attacking
            if (Players[PlayerIndex].PlayerIsAttacking == true)
            {
                foreach (Card card in PlayedCards)
                {
                    foreach (CardBox playerCardBox in pnlPlayerHand.Controls)
                    {
                        if (card.Rank == (playerCardBox.PlayingCard as Card).Rank)
                        {
                            playerCardBox.Enabled = true;
                        }
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

                }

            }

        }


        // TODO: SWITCH THIS TO A METHOD ****************************************************************************
        private void PlayAreaPanel_ControlRemoved(object sender, ControlEventArgs e)
        {
            foreach (CardBox cardBox in pnlOpponentHand.Controls)
            {
                cardBox.Enabled = true;
            }
            foreach (CardBox cardBox in pnlPlayerHand.Controls)
            {
                cardBox.Enabled = true;
            }
        }

        private void btnEndTurn_Click(object sender, EventArgs e)
        {
            //lblDebug.Text = "Player: " + Players[PlayerIndex].PlayerHand.Count().ToString() + "  AI: " + Players[AiIndex].PlayerHand.Count().ToString();

            //if player skips turn while defending
            if (!Players[PlayerIndex].PlayerIsAttacking)
            {
                //picks up all previously played cards
                foreach (Card card in PlayedCards)
                {
                    Players[PlayerIndex].DrawCard(card);
                }
                
            }
            //player skips turns while attacking
            else
            {
                //rotate attackers array, to allow AI to play first
                RotateAttacker();
                ResortPlayers();
            }

            //Disable the AI from playing(calling PlayerHandPanel_ControlRemoved event) during repopulation
            repop = true;

            //Destroy PlayedCards variable
            PlayedCards.Clear();
            //Fill all players hands
            FillPlayerHands(Players);
            //Repopulate and resort all player controlls
            PopulateCardBoxControls(pnlOpponentHand, pnlPlayerHand);
            //Remove card from play area
            pnlPlayArea.Controls.Clear();

            repop = false;

            // Realign the cards 
            RealignCards(pnlPlayerHand);
            RealignCards(pnlOpponentHand);
            lblPlayerStatus.Text = Players[PlayerIndex].PlayerIsAttacking ? "You are Attacking!" : "You Are Defending!";
            

            //check if AI plays need to play first card
            if (!Players[PlayerIndex].PlayerIsAttacking)
                Ai_AttacksFirst(this, new EventArgs());

            //lblDebug.Text = Players[PlayerIndex].PlayerHand.Count.ToString();

        }


        private void GameDeck_OutOfCards(object sender, EventArgs e)
        {
            pbDeck.Visible = false;
            Players[PlayerIndex].PlayerHandOutOfCards += Player_OutOfCards;
            Players[AiIndex].PlayerHandOutOfCards += Player_OutOfCards;
        }

        private void Player_OutOfCards(object sender, EventArgs e)
        {
            DetermineDurak();
            Close();
        }






        #endregion

        #region HELPER METHODS

        static public void DetermineDurak()
        {

            if (Players[PlayerIndex].PlayerHand.Count > Players[AiIndex].PlayerHand.Count)
                MessageBox.Show("Player " + Players[PlayerIndex].PlayerName + ": is the Durak!", "You Lose!", MessageBoxButtons.OK);

            else
                MessageBox.Show("Player " + Players[AiIndex].PlayerName + ": is the Durak!", "You Win!", MessageBoxButtons.OK);

        }

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
            pnlOpponentHand.Controls.Clear();
            pnlPlayArea.Controls.Clear();

        }


        public static void ResetGameVariables(PictureBox pbDeck, PictureBox pbTrump, Panel opponentHand, Panel playerHand, Label playerStatus)
        {
            // Reference Form Objects


            // Create the Players
            Players = new Player[PlayerNum];
            //Players[0] = new Player("Calvin");
            //Players[1] = new Player("Tom");
            Players[0] = new AI("AI1");
            Players[1] = new Player(PlayerName);


            // Create and shuffle a deck
            GameDeck = new Deck(DeckSize);
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
            // Set the Attcking Player
            AttackingPlayer = GetInitialAttacker();
            Players[AttackingPlayer].PlayerIsAttacking = true;
            //PopulateCardBoxControls(opponentHand, playerHand);
            playerStatus.Text = Players[PlayerIndex].PlayerIsAttacking ? "You are Attacking!" : "You Are Defending!";
            ResortPlayers();

            // Reset the PlayedCards List
            PlayedCards = new Cards();

            

            // Set RoundOver as False
            RoundOver = false;
            repop = false;

            
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
            /*while (!Players[0].PlayerIsAttacking)
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
            AttackingPlayer = 0;*/

            Player tempPlayer = Players[0];
            Players[0] = Players[1];
            Players[1] = tempPlayer;

        }

        public static void RotateAttacker()
        {
            /*Players[AttackingPlayer].PlayerIsAttacking = false;

            if (AttackingPlayer == Players.Count() - 1)
            {
                AttackingPlayer = 0;
            }
            else
            {
                AttackingPlayer++;
            }

            Players[AttackingPlayer].PlayerIsAttacking = true;*/

            Players[PlayerIndex].PlayerIsAttacking = !Players[PlayerIndex].PlayerIsAttacking;
            Players[AiIndex].PlayerIsAttacking = !Players[AiIndex].PlayerIsAttacking;
        }

        public void PopulateCardBoxControls(Panel opponentHand, Panel playerHand)
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
                        CardBox cardBox = new CardBox(card);
                        opponentHand.Controls.Add(cardBox);

                    }
                    else
                    {
                        card.FaceUp = true;
                        CardBox cardBox = new CardBox(card);

                        // Wire the Click Event
                        cardBox.Click += CardBox_Click;
                        // Wire the CardBox_MouseEnter event for Visual Effects
                        cardBox.MouseEnter += CardBox_MouseEnter;
                        // Wire CardBox_MouseLeave for the regular Visual Effects
                        cardBox.MouseLeave += CardBox_MouseLeave;

                        playerHand.Controls.Add(cardBox);
                    }
                }

            }


        }

        #endregion

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

