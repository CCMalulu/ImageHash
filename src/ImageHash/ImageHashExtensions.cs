﻿using System;
using System.IO;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace CoenM.ImageSharp
{
    /// <summary>
    /// Extension methods for IImageHash
    /// </summary>
    public static class ImageHashExtensions
    {
        /// <summary>
        /// </summary>
        /// <param name="hashImplementation"></param>
        /// <param name="stream">Stream should 'contain' raw image data</param>
        /// <returns></returns>
        public static ulong Hash(this IImageHash hashImplementation, Stream stream)
        {
            if (hashImplementation == null)
                throw new ArgumentNullException(nameof(hashImplementation));
            if (stream == null)
                throw new ArgumentNullException(nameof(stream));

            using (var image = Image.Load<Rgba32>(stream))
                return hashImplementation.Hash(image);
        }
    }
}