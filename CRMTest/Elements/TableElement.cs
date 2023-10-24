using CRMTest.Extensions;
using OpenQA.Selenium;

namespace CRMTest.Elements
{
    public class TableElement
    {
        private readonly IWebElement _webElement;
        private readonly IWebDriver _webDriver;
        private readonly By _searchFilterLocator = By.Id("filter_text");
        private readonly By _tableLocator = By.ClassName("listView");
        private readonly By _actionsButtonLocator = By.CssSelector(".listview-actions .menu-source");

        private IWebElement _table => _webElement.FindElement(_tableLocator);
        private FormSelectElement _actionElement => new FormSelectElement(_webElement.FindElement(_actionsButtonLocator));

        public TableElement(IWebElement webElement)
        {
            _webElement = webElement;
            _webDriver = _webElement.GetWebDriver();
        }

        public void FilterByValue(string value)
        {
            var searchFilter = _webElement.FindElement(_searchFilterLocator);
            searchFilter.SendKeys(value);
            searchFilter.SendKeys(Keys.Enter);
            _webDriver.WaitForElementToBeInvisible(Application.LoadingLocator);
        }

        public void ClickOnCellValue(int targetColumnIndex, string cellValue)
        {
            IWebElement? specificCell = null;
            var rows = GetRows();
            if (rows.Count == 0)
                return;

            IList<IWebElement> cells = _table.FindElements(By.TagName("td"));
            if (targetColumnIndex < 0 || targetColumnIndex >= cells.Count)
                throw new Exception($"Target column index {targetColumnIndex} is out of range");

            foreach (var row in rows)
            {
                IWebElement cell = cells[targetColumnIndex];
                if (cell.Text == cellValue)
                {
                    specificCell = cell;
                    break;
                }
            }

            if (specificCell == null)
                return;

            specificCell.FindElement(By.XPath($"//*[text()='{cellValue}']/..")).Click();

        }

        public int RowCount()
        {
            return GetRows().Count;
        }

        public int GetTotalRowCount()
        {
            var rowsNumberElement = _webDriver.FindElement(By.CssSelector(".listview-status .text-number:nth-child(2)"));
            return int.Parse(rowsNumberElement.Text);
        }

        public void SelectRows(IList<int> indexes)
        {
            var rows = GetRows();
            foreach (int index in indexes)
            {
                rows[index].Click();
            }
        }

        public void ClickOnAction(string action)
        {
            _actionElement.SetValue(action);
        }

        private IList<IWebElement> GetRows()
        {
            return _table.FindElements(By.TagName("tr"));
        }

    }
}
