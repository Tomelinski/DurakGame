﻿/* Rank.cs - This file contains the Rank class. It contains an enumeration
 *         to represent the different Ranks a single Card object might have.
 * 
 * Author(s): Beginning C# 7 Programming with Visual Studio 2017
 *            Calvin May
 *            
 * Date: 1/24/2021 | Last-Modified: 03/09/2021
 * 
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardLibrary
{
    /// <summary>
    /// A Card Rank Enumeration
    /// </summary>
    public enum Rank
    {
        Ace = 1,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
        Joker
    }
}