using mcga.tools;
using System;
using System.Collections.Generic;
using System.Text;

namespace mcga_tools
{
    public static class UID
    {
        public static Guid CreateUId(string text)
        {
			if(string.IsNullOrWhiteSpace(text))
				return Guid.Empty;

            text = text.Trim();
            string uid = Cryptog.HashBytes(text); //.Substring(0, 42);
            uid = $"{uid.Substring(0, 8)}-{uid.Substring(8, 4)}-{uid.Substring(12, 4)}-{uid.Substring(16, 4)}-{uid.Substring(20)}";
            Guid guid = new Guid(uid.ToLower());
            return guid;

            //var hash = crypto.createHash('sha256').update(str.toString()).digest('hex').substring(0, 36);
            //var chars = hash.split('');
            //chars[8] = '-';
            //chars[13] = '-';
            //chars[14] = '4';
            //chars[18] = '-';
            //chars[19] = '8';
            //chars[23] = '-';
            //hash = chars.join('');
            //return hash;
        }
    }
}
