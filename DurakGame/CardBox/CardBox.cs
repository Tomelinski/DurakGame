/**
 *  MyCardBox.cs - This is the CardBox class.
 * 
  * Author(s): Aadithkeshev Anushayamunaithuraivan,
 *             Menushan Karunakaran,
 *             Calvin May,
 *             Tom Zielinski
 * @version     1.0
 * @since       03/13/2021 |Last Edited: 03/17/2021
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CardLibrary;  // Use the CardLibrary Library

namespace MyCardBox
{
    public partial class CardBox: UserControl
    {

        #region Fields & Properties


        /// <summary>
        /// Card Property: Gets and Sets the Card object being displayed.
        /// </summary>
        private Card playingCard;
        public Card PlayingCard
        {
            set
            {
                // Set the Playing Card &...
                playingCard = value;
                // Update the Card Image
                UpdateCardImage();
            }
            get
            {
                return playingCard;
            }
        }

        /// <summary>
        /// Card Property: Gets and Sets the Suit of the Card object being displayed.
        /// </summary>
        public Suit Suit
        {
            set
            {
                // Set the Suit Value
                PlayingCard.Suit = value;
                // Update the Card Image
                UpdateCardImage();
            }
            get
            {
                return playingCard.Suit;
            }
        }

        /// <summary>
        /// Card Property: Gets and Sets the Suit of the Card object being displayed.
        /// </summary>
        public Rank Rank
        {
            set
            {
                // Set the Rank value
                PlayingCard.Rank = value;
                // Update the Card Image
                UpdateCardImage();
            }
            get
            {
                return playingCard.Rank;
            }
        }
        /// <summary>
        /// Card Property: Gets and Sets the value to determine which side of the Card object is being displayed.
        /// </summary>
        public bool FaceUp
        {
            set
            {
                // Check if the value is different than the current FaceUp value
                if (playingCard.FaceUp != value)    // If it is, we flip the card
                {
                    // Set the face value
                    PlayingCard.FaceUp = value;
                    // Update the Card Image
                    UpdateCardImage();

                    // If there is an event handler for CardFlipped in the Client Program
                    if (CardFlipped != null)
                        // Call it
                        CardFlipped(this, new EventArgs());

                    // The Syntax for this functionality can also be written as:
                    // CardFlipped?.Invoke(this, new EventArgs());
                }
            }
            get
            {
                return playingCard.FaceUp;
            }
        }

        private Orientation cardOrientation;
        public Orientation CardOrientation
        {
            set
            {
                // Check if the value is different from the current Orientation
                if (cardOrientation != value)
                {
                    // If so, set the new Orietntation Value
                    cardOrientation = value;
                    // Change the size of the Control to match the new orientation
                    this.Size = new Size(Size.Height, Size.Width);
                    // Update the Card Image
                    UpdateCardImage();
                }
            }
            get
            {
                return cardOrientation;
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// A Default Constructor for the CardBox Class
        /// </summary>
        public CardBox()
        {
            // Initialize the component for the designer
            InitializeComponent();

            // Set the Orientation to default
            cardOrientation = Orientation.Vertical;
            // Set the Card to default
            playingCard = new Card();
        }

        /// <summary>
        /// Paramaterized Constructor, sets the card and orientation provided
        /// </summary>
        /// <param name="card">The Card to be displayed by the CardBox</param>
        /// <param name="orientation">The Orientation to display the card in - Is vertical by default</param>
        public CardBox(Card card, Orientation orientation = Orientation.Vertical)
        {
            // Initialize the component for the designer
            InitializeComponent();

            // Set the Orientation
            cardOrientation = orientation;
            // Set the Card
            playingCard = card;
        }
        #endregion

        #region Events & Event Handlers
        /// <summary>
        /// An Event Handler for the CardBox Load Event,
        /// All it does is update the Card image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CardBox_Load(object sender, EventArgs e)
        {
            UpdateCardImage();
        }


        /// <summary>
        /// An event the client program can handle when the user clicks the control
        /// This is an Event Delegate!
        /// </summary>
        new public event EventHandler Click;

        /// <summary>
        /// An event handler for the user clicking the picturebox control
        /// This Functionality should change depending on the program using this
        /// Control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PbCardPictureBox_Click(object sender, EventArgs e)
        {
            // Check if there is a handler for clicknig the control in the client program
            if (Click != null)
                // If there is, Call it
                Click(this, e);

            // Syntax for this functionality can also be done like this:
            // Click?.Invoke(this, e);
        }

        /// <summary>
        /// An event the client program can handle when the user clicks the control
        /// This is an Event Delegate!
        /// </summary>
        new public event EventHandler MouseLeave;

        /// <summary>
        /// An event handler for the user clicking the picturebox control
        /// This Functionality should change depending on the program using this
        /// Control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PbCardPictureBox_MouseLeave(object sender, EventArgs e)
        {
            // Check if there is a handler for clicknig the control in the client program
            if (MouseLeave != null)
                // If there is, Call it
                MouseLeave(this, e);

            // Syntax for this functionality can also be done like this:
            // Click?.Invoke(this, e);
        }

        /// <summary>
        /// An event the client program can handle when the user clicks the control
        /// This is an Event Delegate!
        /// </summary>
        new public event EventHandler MouseEnter;

        /// <summary>
        /// An event handler for the user clicking the picturebox control
        /// This Functionality should change depending on the program using this
        /// Control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PbCardPictureBox_MouseEnter(object sender, EventArgs e)
        {
            // Check if there is a handler for clicknig the control in the client program
            if (MouseEnter != null)
                // If there is, Call it
                MouseEnter(this, e);

            // Syntax for this functionality can also be done like this:
            // Click?.Invoke(this, e);
        }

        /// <summary>
        /// An event the client program can handle when the Card is flipped
        /// </summary>
        public event EventHandler CardFlipped;

        #endregion

        #region Methods

        private void UpdateCardImage()
        {
            // Set the image using the current Card Object
            pbCardPictureBox.Image = playingCard.GetCardImage();

            // If the Orientation is horizontal
            if (cardOrientation == Orientation.Horizontal)
            {
                // Rotate the image
                pbCardPictureBox.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            }
        }

        /// <summary>
        /// A ToString() Override Method, returns the ToString() method of the Card contained in the
        /// PictureBox
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return playingCard.ToString();
        }

        #endregion

    }
}
