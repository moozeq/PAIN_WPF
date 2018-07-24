WPF, MVVM application to manage bookshop by adding, editing, filtering books.  
View -> Viewmodel communicating by commands & data binding.  
Viewmodel updates model through interface 'BooksMgmt' immediately when property changed.  

- User control - /view/CategoryPicker file  
- Validators - /validators/...Rule files  
- Converters - /view/...Converter files  

'Add' button adds new book.  
Category is picked by clicking image.  
Filter is active when checkbox 'A' is checked.  
Filter is filtering dates before input year when checkbox 'B4' is checked and date in textfield is correct.
