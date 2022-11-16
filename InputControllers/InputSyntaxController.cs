        public string Input_EditSyntax(string input)
        {
            string result = "";
            int charInt = 0;
            input = input.Replace("\'", "").Replace("\"", "").Replace("\\", "").Replace("\0", "").Replace("\a", "");
            input = input.Replace("\b", "").Replace("\f", "").Replace("\n", "").Replace("\r", "").Replace("\v", "");
            for (int i = 0; i < input.Length; i++)
            {
                charInt = Convert.ToInt16(input[i]);
                //(charInt >= 48 && charInt <= 57) : numbers 0-9
                //(charInt >= 65 && charInt <= 90) : UpperCase Chars
                //(charInt >= 97 && charInt <= 122): LowerCase Chars
                if ((charInt >= 48 && charInt <= 57) || (charInt >= 65 && charInt <= 90) || (charInt >= 97 && charInt <= 122))
                {
                    result += input[i];
                }
            }
            return result;
        }
