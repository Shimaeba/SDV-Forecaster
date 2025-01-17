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
    internal sealed class MessageSource : ISourceMessage {
        public string T9N;
        public ISourceMessage Message;
        
        private MessageSource(string t9N, ISourceMessage message) {
            this.T9N = $"source.{t9N}";
            this.Message = message;
        }
        
        /// <inheritdoc/>
        public string Write(Farmer farmer, ITranslationHelper t9N, ForecasterConfig config)
            => t9N.Get(this.T9N, new {
                content = this.Message.Write(farmer, t9N, config)
            });
        
        public static MessageSource TV(ISourceMessage message)
            => message is null ? null : new MessageSource("tv", message);
        
        public static MessageSource Calendar(ISourceMessage message)
            => message is null ? null : new MessageSource("calendar", message);
    }
}
