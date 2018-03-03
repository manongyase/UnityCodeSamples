/*
------------------------------------------------------------------------------------------------------------------------
 * Copyright (c) 2018 scott.cgi All Rights Reserved.
 * 
 * This code is licensed under the MIT License.
 *
 * Since  : 2018-3-3
 * Author : scott.cgi
------------------------------------------------------------------------------------------------------------------------
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Drap on Inspector.
/// </summary>
public class IngredientDisplay : MonoBehaviour
{
    public Ingredient   potionResult;
    public Ingredient[] potionIngredients;


//----------------------------------------------------------------------------------------------------------------------


    public enum IngredientUnit 
    { 
        Spoon,
        Cup,
        Bowl, 
        Piece,
    }


    /// <summary>
    /// Custom serializable class by IngredientDrawer.
    /// </summary>
    [System.Serializable]
    public class Ingredient
    {
        public string         name;
        public int            amount;
        public IngredientUnit unit;
    }
}
