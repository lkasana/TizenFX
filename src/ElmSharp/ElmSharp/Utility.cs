/*
 * Copyright (c) 2017 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the License);
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an AS IS BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

namespace ElmSharp
{
    /// <summary>
    /// This class is a static class for a utility methods.
    /// </summary>
    public static class Utility
    {
        /// <summary>
        /// Appends a font path to the list of font paths used by the application.
        /// </summary>
        /// <param name="path">The new font path.</param>
        public static void AppendGlobalFontPath(string path)
        {
            Interop.Evas.evas_font_path_global_append(path);
        }

        /// <summary>
        /// Prepends a font path to the list of font paths used by the application.
        /// </summary>
        /// <param name="path">The new font path.</param>
        public static void PrependEvasGlobalFontPath(string path)
        {
            Interop.Evas.evas_font_path_global_prepend(path);
        }

        /// <summary>
        /// Removes all font paths loaded into memory by evas_font_path_app_* APIs for the application.
        /// </summary>
        public static void ClearEvasGlobalFontPath()
        {
            Interop.Evas.evas_font_path_global_clear();
        }

        /// <summary>
        /// Sets Edje color class.
        /// </summary>
        /// <param name="colorClass">Color class</param>
        /// <param name="red">Object Red value</param>
        /// <param name="green">Object Red value</param>
        /// <param name="blue">Object Red value</param>
        /// <param name="alpha">Object Red value</param>
        /// <param name="outlineRed">Outline Red value</param>
        /// <param name="outlineGreen">Outline Green value</param>
        /// <param name="outlineBlue">Outline Blue value</param>
        /// <param name="outlineAlpha">Outline Alpha value</param>
        /// <param name="shadowRed">Shadow Red value</param>
        /// <param name="shadowGreen">Shadow Green value</param>
        /// <param name="shadowBlue">Shadow Bluevalue</param>
        /// <param name="shadowAlpha">Shadow Alpha value</param>
        /// <returns></returns>
        public static bool SetEdjeColorClass(string colorClass, int red, int green, int blue, int alpha, int outlineRed, int outlineGreen, int outlineBlue, int outlineAlpha,
            int shadowRed, int shadowGreen, int shadowBlue, int shadowAlpha)
        {
            return Interop.Elementary.edje_color_class_set(colorClass, red, green, blue, alpha, outlineRed, outlineGreen, outlineBlue, outlineAlpha, shadowRed, shadowGreen, shadowBlue, shadowAlpha);
        }

        /// <summary>
        /// Gets Edje color class.
        /// </summary>
        /// <param name="colorClass">Color class</param>
        /// <param name="red">Object Red value</param>
        /// <param name="green">Object Red value</param>
        /// <param name="blue">Object Red value</param>
        /// <param name="alpha">Object Red value</param>
        /// <param name="outlineRed">Outline Red value</param>
        /// <param name="outlineGreen">Outline Green value</param>
        /// <param name="outlineBlue">Outline Blue value</param>
        /// <param name="outlineAlpha">Outline Alpha value</param>
        /// <param name="shadowRed">Shadow Red value</param>
        /// <param name="shadowGreen">Shadow Green value</param>
        /// <param name="shadowBlue">Shadow Bluevalue</param>
        /// <param name="shadowAlpha">Shadow Alpha value</param>
        /// <returns></returns>
        public static bool GetEdjeColorClass(string colorClass, out int red, out int green, out int blue, out int alpha, out int outlineRed, out int outlineGreen, out int outlineBlue,
            out int outlineAlpha, out int shadowRed, out int shadowGreen, out int shadowBlue, out int shadowAlpha)
        {
            return Interop.Elementary.edje_color_class_get(colorClass, out red, out green, out blue, out alpha, out outlineRed, out outlineGreen, out outlineBlue, out outlineAlpha,
                out shadowRed, out shadowGreen, out shadowBlue, out shadowAlpha);
        }

        /// <summary>
        /// Processes all queued up edje messages.
        /// This function triggers the processing of messages addressed to any (alive) edje objects.
        /// </summary>
        public static void ProcessEdjeMessageSignal()
        {
            Interop.Elementary.edje_message_signal_process();
        }

        /// <summary>
        /// Sets the Edje text class.
        /// </summary>
        /// <param name="textClass">The text class name</param>
        /// <param name="font">The font name</param>
        /// <param name="size">The font size</param>
        /// <returns>True, on success or false, on error</returns>
        public static bool SetEdjeTextClass(string textClass, string font, int size)
        {
            return Interop.Elementary.edje_text_class_set(textClass, font, size);
        }

        /// <summary>
        /// Gets the Edje text class.
        /// </summary>
        /// <param name="textClass">The text class name</param>
        /// <param name="font">The font name</param>
        /// <param name="size">The font size</param>
        /// <returns>True, on success or false, on error</returns>
        public static bool GetEdjeTextClass(string textClass, out string font, out int size)
        {
            return Interop.Elementary.edje_text_class_get(textClass, out font, out size);
        }

        /// <summary>
        /// Delete the text class.
        /// </summary>
        /// <param name="textClass"></param>
        public static void DeleteEdjeTextClass(string textClass)
        {
            Interop.Elementary.edje_text_class_del(textClass);
        }

        /// <summary>
        /// Pre-multiplies a rgb triplet by an alpha factor.
        /// </summary>
        /// <param name="alpha">The alpha factor</param>
        /// <param name="red">The Red component of the color</param>
        /// <param name="green">The Green component of the color</param>
        /// <param name="blue">The Blue component of the color</param>
        public static void PremulityplyEvasColorByAlpha(int alpha, ref int red, ref int green, ref int blue)
        {
            Interop.Evas.evas_color_argb_premul(alpha, ref red, ref green, ref blue);
        }

        /// <summary>
        /// Undoes pre-multiplies a rgb triplet by an alpha factor.
        /// </summary>
        /// <param name="alpha">The alpha factor</param>
        /// <param name="red">The Red component of the color</param>
        /// <param name="green">The Green component of the color</param>
        /// <param name="blue">The Blue component of the color</param>
        public static void UnPremulityplyEvasColorByAlpha(int alpha, ref int red, ref int green, ref int blue)
        {
            Interop.Evas.evas_color_argb_unpremul(alpha, ref red, ref green, ref blue);
        }
    }
}