using System;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;

namespace Apple.MapKit.RestClient
{
    /// <summary>
    ///     Based on code samples done by Adam Russell
    ///     https://www.adamrussell.com/mapkit-js-with-asp-net-core/
    /// </summary>
    public static class CryptographicHelper
    {
        public static string CreateJWT(string privateKeyContent, string teamId, string keyId, string origin="")
        {
            var header = Base64EncodeJWT(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(new TokenHeader(keyId))));
            var payload = Base64EncodeJWT(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(new TokenPayload(teamId, origin))));

            var unsigned = $"{header}.{payload}";
            var signature = CreateSignature(privateKeyContent, unsigned);
            return $"{header}.{payload}.{Base64EncodeJWT(signature)}";
        }

        public static byte[] CreateSignature(string privateKeyContent, string data)
        {
            using (var ECDSA =
                new ECDsaCng(CngKey.Import(GetBytesFromPrivateKeyContent(privateKeyContent), CngKeyBlobFormat.Pkcs8PrivateBlob)))
            {
                return ECDSA.SignData(Encoding.UTF8.GetBytes(data));
            }
        }

        public static byte[] GetBytesFromPrivateKeyContent(string content)
        {
            if (string.IsNullOrEmpty(content)) throw new ArgumentNullException("Private Key Content");

            var base64Str = content.Replace("-----BEGIN PRIVATE KEY-----", "")
                .Replace("-----END PRIVATE KEY-----", "")
                .Replace("\n", "")
                .Replace("\r", "");
            return Convert.FromBase64String(base64Str);
        }

        public static string Base64EncodeJWT(byte[] bytes)
        {
            if (bytes == null)
                throw new ArgumentNullException(nameof(bytes));
            if (bytes.Length == 0)
                throw new ArgumentOutOfRangeException(nameof(bytes));
            return Convert.ToBase64String(bytes)
                .Replace('+', '-')
                .Replace('/', '_')
                .TrimEnd('=');
        }
    }

    public class TokenHeader
    {
        public TokenHeader(string keyIdentifier)
        {
            kid = keyIdentifier;
        }

        /// <summary>
        ///     Algorithm you used to encrypt the token, ES256 algorithm.
        /// </summary>
        public string alg => "ES256";

        public string typ => "JWT";

        /// <summary>
        ///     10-character key identifier that provides the ID of the private key.
        /// </summary>
        public string kid { get; }
    }

    public class TokenPayload
    {
        public TokenPayload(string teamIdentifier, string Origin)
        {
            iss = teamIdentifier;
            origin = Origin;
        }

        /// <summary>
        ///     Issuer of the token, this is the 10-character Team ID.
        /// </summary>
        public string iss { get; }

        /// <summary>
        ///     The Issued At registered claim key. The value of this claim indicates the token creation time, in terms of the number of seconds since
        ///     UNIX Epoch, in UTC.
        /// </summary>
        public long iat => DateTimeOffset.Now.ToUnixTimeSeconds();

        /// <summary>
        ///     The Expiration Time registered claim key. The value of this claim indicates when the token expires, in terms of the number of seconds
        ///     since UNIX Epoch, in UTC.
        /// </summary>
        public long exp => DateTimeOffset.Now.AddHours(1).ToUnixTimeSeconds();

        public string origin { get; }
    }
}