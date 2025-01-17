/*
 * This software is licensed under the MIT License
 * https://github.com/GStefanowich/SDV-Forecaster
 *
 * Copyright (c) 2019 Gregory Stefanowich
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */

using StardewModdingAPI;
using StardewValley;

namespace ForecasterText.Objects.Messages {
    public sealed class QueenOfSauceMessage : ISourceMessage {
        private readonly ModEntry Mod;
        
        public QueenOfSauceMessage(ModEntry mod) {
            this.Mod = mod;
        }
        
        /// <inheritdoc />
        public string Write(Farmer farmer, ITranslationHelper t9N, ForecasterConfig config) {
            IRecipeFinder recipeFinder = this.Mod.GetRecipeFinder(farmer);
            
            // Get the recipe name
            if (recipeFinder.GetAnyRecipe() is not string recipeName)
                return null;
            
            bool hasRecipe = this.PlayerHasRecipe(farmer, recipeName);
            if ((hasRecipe && !config.ShowExistingRecipes) || (!hasRecipe && !config.ShowNewRecipes))
                return null;
            
            return ISourceMessage.GetQueenOfSauce(recipeName, hasRecipe)
                .Write(farmer, t9N, config);
        }
        
        /// <summary>Check if a farmer knows a recipe</summary>
        public bool PlayerHasRecipe(Farmer farmer, string recipe)
            => farmer.cookingRecipes.ContainsKey(recipe);
    }
}
