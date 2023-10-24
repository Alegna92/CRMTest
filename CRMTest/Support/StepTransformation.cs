namespace CRMTest.Support
{
    [Binding]
    public class StepTransformation
    {
        [StepArgumentTransformation]
        public List<int> TranformStringToListOfInt(string input)
        {
            List<int> result = new List<int>();
            if (string.IsNullOrEmpty(input))
                return result;
            string[] values = input.Split(',');

            foreach (string value in values)
            {
                if (int.TryParse(value, out int intValue))
                {
                    result.Add(intValue);
                }
            }
            return result;
        }
    }
}
