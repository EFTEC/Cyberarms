using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cyberarms.IntrusionDetection.Shared.Db {
    public class DbValueConverter {
        public static bool ToBool(object value) {
            if (value == DBNull.Value) return false;
            bool result;
            bool.TryParse(value.ToString(), out result);
            return result;
        }

        public static string ToString(object value) {
            if (value == DBNull.Value) return String.Empty;
            return value.ToString();
        }

        public static int ToInt(object value) {
            if (value == DBNull.Value) return 0;
            int result;
            int.TryParse(value.ToString(), out result);
            return result;
        }

        public static long ToInt64(object value) {
            if (value == DBNull.Value) return 0;
            long result;
            long.TryParse(value.ToString(), out result);
            return result;
        }

        public static Guid ToGuid(object value) {
            string textValue = ToString(value);
            Guid result;
            if (!Guid.TryParse(textValue, out result)) {
                throw new ArgumentException(value + " is not a unique id");
            }
            return result;            
        }

        public static DateTime ToDateTime(object value) {
            if(value==DBNull.Value) return DateTime.MinValue;
            DateTime result;
            if(!DateTime.TryParse(ToString(value), out result)) {
                throw new ArgumentException(value + " is not a valid date");
            }
            return result;
        }
    }
}
