//using PerondaApp.Data.Entities;
//using Microsoft.EntityFrameworkCore;

//namespace PerondaApp.Data.Repositories;

//public delegate void ItemAddedCalback(object item);
//public delegate void ItemAdded<in T>(T item);

//public class SqlRepositoryMyVersion<T> : IRepository<T> where T : class, IEntity, new()
//{
//    private readonly DbContext _dbContext;
//    private readonly DbSet<T> _dbSet;
//    private readonly ItemAddedCalback? _itemAddedCallback;
//    private readonly ItemRemovedCallback? _itemRemovedCallback;
//    private readonly ItemAdded<T>? _itemAdded;

//    public SqlRepositoryMyVersion(DbContext dbContext, ItemAddedCalback? itemAddedCallback = null,//, ItemRemoved? itemRemovedCallback = null)
//        ItemAdded<T>? itemAdded = null)
//    {
//        _dbContext = dbContext;
//        _dbSet = _dbContext.Set<T>();
//        _itemAddedCallback = itemAddedCallback;   //to jest przepisany delegat
//        //_itemRemovedCallback = itemRemovedCallback;
//        _itemAdded = itemAdded;
//    }

//    public event ItemAdded<T>? ItemAdded;
//    public event EventHandler<T>? ItemRemoved;

//    public IEnumerable<T> GetAll()
//    {
//        return _dbSet.ToList();
//    }

//    public T? GetById(int id)
//    {
//        return _dbSet.Find(id);
//    }

//    public void Add(T item)
//    {
//        _dbSet.Add(item);
//        _itemAddedCallback?.Invoke(item);  //tu uruchamia się delegat i przekazuje sie dodany item
//        _itemAdded?.Invoke( item);   //  EventHandler<T>
//    }

//    public void Remove(T item)
//    {
//        _dbSet.Remove(item);
//        _itemRemovedCallback?.Invoke(item);
//        //_itemRemoved?.Invoke(this, item);
//    }

//    public void Save()
//    {
//        _dbContext.SaveChanges();
//    }

//    public IEnumerable<T> Read()
//    {
//        return _dbSet.ToList();
//    }

//    public int GetListCount()
//    {
//        return Read().ToList().Count;
//    }
//}

///* https://www.modestprogrammer.pl/to-musisz-wiedziec-o-serializacji-i-deserializacji-json-w-csharpie
//Serializacja to proces przekształcania obiektów do strumieni bajtów z zachowaniem aktualnego stanu. 
//Dzięki czemu obiekt może zostać utrwalony np. w pliku, może też zostać przesłany do innego procesu czy komputera przez sieć.

//Natomiast deserializacja jest procesem odwrotnym do serializacji, to znaczy dzięki niej możemy odczytać ten strumień bajtów i przywrócić obiekt do stanu sprzed serializacji.

//_______________
//1 Serializacja jest bardzo prosta, wystarczy wywołać statyczną metodę SerializeObject z klasy JsonConvert i przekazać obiekt, który chcemy serializować.
//2 Teraz tekst w formacie JSON zapiszemy sobie w pliku. Przygotujmy najpierw ścieżkę do pliku.
//3 I zapiszemy do tego pliku dane.
//ad.1
//var json = JsonConvert.SerializeObject(_purchases);
//ad2.
//private string _filePath = Path.Combine(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory), "data.json");
//ad.3
//File.WriteAllText(_filePath, json);
//___________
//Wczytywanie możemy zrobić np. w konstruktorze lub podpiąć się pod zdarzenie Load. Skorzystamy z pierwszego sposobu. Najpierw w konstruktorze wczytamy dane z pliku i zapiszemy w zmiennej o nazwie json.
//var json = File.ReadAllText(_filePath);
//Warto wcześniej jeszcze sprawdzić, czy ten plik istnieje na dysku, bo jeżeli teraz go nie będzie, to zostanie rzucony wyjątek i nasza aplikacja przestanie działać. Dodajmy instrukcje warunkową, która sprawdzi czy plik istnieje. Jeżeli plik nie istnieje, to zostanie on utworzony.
//if (!File.Exists(_filePath))
//{
//    File.Create(_filePath).Dispose();
//}

//var json = File.ReadAllText(_filePath);
//Zmienna, którą utworzyliśmy - json przechowuje tekst w formacie JSON.
//Teraz wystarczy skorzystać z deserializacji i zamienić JSONa na obiekt w C#, w tym przypadku naszym obiektem będzie BindingList<Purchase> i taki typ generyczny przekażemy do metody statycznej tym razem DeserializeObject tej samej klasy JsonConvert.
//Jako argument przekażemy tekst w formacie JSON.
//_purchases = JsonConvert
//    .DeserializeObject<BindingList<Purchase>>(json);
//Musimy jeszcze w tym miejscu dodać jedno zabezpieczenie, przed sytuacją w której ten plik będzie pusty, ponieważ wtedy lista będzie nullem i zostanie rzucony wyjątek przy próbie dodania nowego zakupu.
//W tym celu wystarczy po deserializacji dodać instrukcję warunkową, gdzie sprawdzimy wartość listy _purchases i jeżeli jest ona nullem lub pustą listą, to chcemy ją zainicjalizować:
//if (_purchases == null || !_purchases.Any())
//    _purchases = new BindingList<Purchase>();

//Typ aplikacji nie ma tutaj żadnego znaczenia, w każdej aplikacji stworzonej w C# proces serializacji i deserializacji wygląda tak samo. Także możesz stworzyć zarówno jakąś aplikację desktopową na komputer, mobilną czy webową.
//Poniżej kod do aplikacji Windows Forms
//__________
//public partial class Form1 : Form
//{
//    private BindingList<Purchase> _purchases = new BindingList<Purchase>();
//    private string _filePath = Path.Combine(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory), "data.json");

//    public Form1()
//    {
//        InitializeComponent();

//        CreateDataFile();

//        GetData();

//        dgvShopping.DataSource = _purchases;
//    }

//    private void btnAdd_Click(object sender, EventArgs e)
//    {
//        AddPurchase();

//        SaveData();

//        ClearFields();
//    }

//    private void ClearFields()
//    {
//        tbName.Text = "";
//        nudAmount.Value = 0;
//    }

//    private void SaveData()
//    {
//        var json = JsonConvert.SerializeObject(_purchases);

//        File.WriteAllText(_filePath, json);
//    }

//    private void AddPurchase()
//    {
//        var purchase = new Purchase
//        {
//            Amount = nudAmount.Value,
//            Name = tbName.Text,
//            CreatedDate = DateTime.UtcNow,
//        };

//        _purchases.Add(purchase);
//    }

//    private void GetData()
//    {
//        var json = File.ReadAllText(_filePath);

//        _purchases = JsonConvert.DeserializeObject<BindingList<Purchase>>(json);

//        if (_purchases == null || !_purchases.Any())
//            _purchases = new BindingList<Purchase>();
//    }

//    private void CreateDataFile()
//    {
//        if (!File.Exists(_filePath))
//        {
//            File.Create(_filePath).Dispose();
//        }
//    }
//}
// */
