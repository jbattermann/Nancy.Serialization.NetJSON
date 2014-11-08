﻿using System.Collections.Generic;
using System.IO;
using Nancy.IO;

namespace Nancy.Serialization.NetJSON
{
    /// <summary>
    /// A <see cref="ISerializer"/> implementation based on <see cref="NetJSON"/>.
    /// </summary>
    public class NetJSONSerializer : ISerializer
    {
        
        #region Implementation of ISerializer

        /// <summary>
        /// Whether the serializer can serialize the content type
        /// </summary>
        /// <param name="contentType">Content type to serialize</param>
        /// <returns>
        /// True if supported, false otherwise
        /// </returns>
        public bool CanSerialize(string contentType)
        {
            return Helpers.IsJsonType(contentType);
        }

        /// <summary>
        /// Serializes the given model instance with the given contentType
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <param name="contentType">Content type to serialize into</param>
        /// <param name="model">Model instance to serialize.</param>
        /// <param name="outputStream">Output stream to serialize to.</param>
        public void Serialize<TModel>(string contentType, TModel model, Stream outputStream)
        {
            using (var output = new StreamWriter(new UnclosableStreamWrapper(outputStream)))
            {
                global::NetJSON.NetJSON.Serialize(model, output);
            }
        }

        /// <summary>
        /// Gets the list of extensions that the serializer can handle.
        /// </summary>
        /// <value>
        /// An <see cref="T:System.Collections.Generic.IEnumerable`1"/> of extensions if any are available, otherwise an empty enumerable.
        /// </value>
        public IEnumerable<string> Extensions
        {
            get { yield return "json"; }
        }

        #endregion
    }
}
