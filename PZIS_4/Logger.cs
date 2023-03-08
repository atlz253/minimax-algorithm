using System;
using System.Windows.Controls;

namespace PZIS_4
{
    /// <summary>
    /// Отвечает за печать отладочных сообщений
    /// </summary>
    internal static class Logger
    {
        private static TextBlock? textBlock;

        /// <summary>
        /// Текстовый блок для печати сообщений
        /// </summary>
        public static TextBlock? TextBlock
        {
            get => textBlock;

            set => textBlock = value;
        }

        /// <summary>
        /// Печатает отладочные сообщения
        /// </summary>
        /// <param name="message">сообщение для печати</param>
        public static void Log(string message)
        {
            if (TextBlock == null)
            {
                return;
            }

            TextBlock.Text = $"{TextBlock.Text}\n\t{DateTime.Now}: {message}";
        }
    }
}
