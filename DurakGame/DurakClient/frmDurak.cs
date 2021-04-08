using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CardBox;
using CardLibrary;

namespace DurakClient
{
    public partial class frmDurak : Form
    {
        // Deck Settings
        Deck deck;
        Cards collection = new Cards();
        Cards addCard = new Cards();


        // Storing the Deck and Card
        CardBox.CardBox deckBox;
        CardBox.CardBox trumpCard;
        public frmDurak(int deckSize, int playerNum)
        {
            InitializeComponent();

            deck = new Deck(deckSize);
            //deck = deck.Shuffle();
        }


        private void Deck()
        {
            // Create deck and trump cardBox
            deckBox = new CardBox.CardBox();
            trumpCard = new CardBox.CardBox(deck.getTrumpCard());

            // Cardbox Orientation
            trumpCard.CardOrientation = Orientation.Horizontal;
            trumpCard.FaceUp = true;

            // Cardbox Location
            deckBox.Location = new Point(10, 100);
            deckBox.Location = new Point(5, 200);

            // Cardbox Controls
            this.Controls.Add(deckBox);
            this.Controls.Add(trumpCard);
        }


        private void insertCardPanel(Card card, Panel addPanel)
        {
            CardBox.CardBox panelCardBox = new CardBox.CardBox(card);

            // Set Cardbox Size
            
        }
    }
}
