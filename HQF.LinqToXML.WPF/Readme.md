#LinqToXmlDataBinding Demo

The LinqToXmlDataBinding program is a Windows Presentation Foundation (WPF) application that is composed of C# and XAML source files. It contains an embedded XML document that defines a list of books, and enables the user to view, add, delete, and edit these entries. It is composed of the following two primary source files:

1. `L2DBForm.xaml` contains the XAML declaration code for the user interface (UI) of the main window. It also contains a window resource section that defines a data provider and embedded XML document for the book listings.

2. `L2DBForm.xaml.cs` contains the initialization and event-handling methods associated with the UI.

3. The main window is divided into the following four vertical UI sections:

4. XML displays the raw XML source of the embedded book listing.

5. Book List displays the book entries as standard text and enables the user to select and delete individual entries.

6. Edit Selected Book enables the user to edit the values associated with the currently selected book entry.

7. Add New Book enables the creation of a new book entry based on values entered by the user.


##DataSource
    <!-- Books provider and inline data -->
        <ObjectDataProvider x:Key="LoadedBooks" ObjectType="{x:Type xlinq:XElement}" MethodName="Parse">
            <ObjectDataProvider.MethodParameters>
                <system:String xml:space="preserve">
    <![CDATA[
    <books xmlns="http://www.mybooks.com">
    <book id="0">book zero</book>
    <book id="1">book one</book>
    <book id="2">book two</book>
    <book id="3">book three</book>
    </books>
    ]]>                
                </system:String>
                <xlinq:LoadOptions>PreserveWhitespace</xlinq:LoadOptions>
            </ObjectDataProvider.MethodParameters>
        </ObjectDataProvider>

## How Bind XML To ListBox
    <ListBox Name="lbBooks" Height="200" Width="415" ItemTemplate ="{StaticResource BookTemplate}">
                <ListBox.ItemsSource>
                    <Binding Path="Elements[{http://www.mybooks.com}book]"/>
                </ListBox.ItemsSource>
    </ListBox>

##How add book into xml
    XElement bookList = (XElement)((ObjectDataProvider)Resources["LoadedBooks"]).Data;

    void OnAddBook(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tbAddID.Text) ||
                String.IsNullOrEmpty(tbAddValue.Text))
            {
                MessageBox.Show("Please supply both a Book ID and a Value!", "Entry Error!");
                return;
            }
            XElement newBook = new XElement(
                                mybooks + "book",
                                new XAttribute("id", tbAddID.Text),
                                tbAddValue.Text);
            bookList.Add("  ", newBook, "\r\n");
        }

##How to Remove the book
    XElement selBook = (XElement)lbBooks.SelectedItem;
            //Get next node before removing element.
            XNode nextNode = selBook.NextNode;
            selBook.Remove(); 