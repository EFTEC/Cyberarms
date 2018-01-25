using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace Cyberarms.IntrusionDetection.Shared {
    
    public class VolumeLicenseManager {
        private const string ENC_MSG = "__adlBN;MBNCYBERARMSLad8KJLKnasd;MNwer890zhlmsdbnv";
        private const string PRI_XML = "<RSAKeyValue><Modulus>3zX38i2nLFHjUD29hLsTFkddbKd9IHRzRT4KXTN64BMZ+oJ7WOyV8cUh7PRSdgcjO8tysruOCI81WtKnEJ/YYd3bAAcpouL7PY8SUbcxmx0EF/QtijJ0wlW1B2JLI7LpYz9oRiKKRT8DugkdVvVYHfw+J5b8S3qOCfYhtjakvNSFIY/+Gf8ltwYXQFi8L+Was5RUakSCLhbHo0TjYI0YDhGlq8CAwB9MAb015AufkHQCSZWk+taxorqw+H9zfKOeeGsElhcwEv2r2mZ4eFBoOipKkcdNHDJdoS9ecScyPZlMdtG6RYhxVr6XzIDX1vpMXat31Uw41hrqTwaEKhd8vQ==</Modulus><Exponent>AQAB</Exponent><P>+VmphZDBRmtqFM6zbF5JZi8K9BdkUD4Q6OSgAAn7prCygpcLj0ZM9QKpVVN7oyE8XWzw/3OEt9CkTdjbQcgUFA7VF3NLEzXQKPVgdPgNyGKQ2ZHX5UCE4EHT3QGTPnIs3QQk5fBdKwcdHjlACiEHoIL6k4Ba85I7TlpVo0J1nr8=</P><Q>5SnZmII5LoaO1oBx5Y/rezAA16ds2LDr+TY8QxfP32cKLyKVXsxoQZ2MvBvRpbHuxjC7GaEXG7MGKEVWKWkM+qdIvEw00sirRn7m/tiXWZo2uijA1pq+x4m0S67W76+8uwAQj7mq8khFWwEUvD+2uZP+HqgB0oE2gPX0jin5/4M=</Q><DP>xSc5vFvKFc3UYINWpnaefmbvuDPOowuP/zTVtXIvQYswecTH5Q7mxkrGbKrHdSJQQmZi3vgNlfEoGE1Af3CdP4bCwfntAFFqNxhcnd+LtkcI1J5WH/O1nEMwKuyV6agJBO/D5PL6F41WXpFRqzCWgTlOutWgFDopHjiawa1Ipq0=</DP><DQ>Edx1LUHZGxs5vtY8ClxxSiSvrB9MiIchnUbw43nTpeHuFUZoxf7AkXyqH287o+J+bcwWiSTZHDuT20esM4YQkOjA7owyAcvKLbBuaKaRBVbTtSbAAPoGrJ67ArsZ3Yyg9SJIKCuce03Oug0XhKSipUw3nkQSAEo56UtCSGJVLek=</DQ><InverseQ>4d1ZTo/m9HU3ZXQ5tz1gOOEPPL7wtcUerKRufo58WU0YKzUv3EYdGgspJKm+fJIhnOg9hYwUjfmHYSlqFzm3t6QT0VSELclVjg8zu+n2I3yRCUeB7YwgLeL1Rjw4q9D0qZgG38Ngk46oijuKgZB5C9by7vvXIfz5kRFdI/Cxdzg=</InverseQ><D>O/CjL66gyN8ImuCphv4xpvbtGKN1j4SV+88oO1T6tzeJ72KguwV1UqJsdNQ7XKSYCpOcrnB9OME0Q7pz0JwMIGPSTpSd0rb/Xs2Pzs/SC2RkWAZjQExCXHlljqEPqnt9/v/lAYh+9w9v8cJG1bY2vn6hNkJuZ9p2UCh/bw4HeQlcYu70Lg5NZe0ekrwK2a8aZZ/wi5IDMlXC9Lmb5p5Wkv7HL4rY+aaWLUV8PblrU5NA8Itb3SyLv229UChKQ/TApB3UcpvX8d/zVj0YI+pzh0J99RT1PqmbvM8VOTfI5aJuY6ShK9zvM7bCIuCgo85/Rgr12HXIrIt6y1NJKNLuhQ==</D></RSAKeyValue>";

        public bool CheckLicense(byte[] license) {
            try {
                var rsaPrivate = new RSACryptoServiceProvider();
                rsaPrivate.FromXmlString(PRI_XML);
                byte[] decryptedRSA = rsaPrivate.Decrypt(license, false);
                string originalResult = Encoding.Default.GetString(decryptedRSA);
                string[] result = originalResult.Split('|');
                if (result.Length == 4) {
                    if (result[3] != ENC_MSG) return false;
                    this.LicenseTaker = result[0];
                    this.PurchaseInfo = result[1];
                    this.LicenseCount = result[2];
                    return true;
                }
            } catch {
                this.PurchaseInfo = "License not valid!";
            }
            return false;
        }

        public bool CheckLicense(string licenseFile) {
            try {
                return CheckLicense(GetBytes(licenseFile));
            } catch {
                return false;
            }
        }


        public byte[] GetBytes(string filename) {
            if (!File.Exists(filename)) throw new ApplicationException("File does not exist!");
            FileStream fs = File.OpenRead(filename);
            byte[] result = new byte[fs.Length];
            fs.Read(result, 0, (int)fs.Length);
            fs.Close();
            return result;
        }

        public string LicenseTaker { get; set; }
        public string LicenseCount { get; set; }
        public string PurchaseInfo { get; set; }
    }
}
