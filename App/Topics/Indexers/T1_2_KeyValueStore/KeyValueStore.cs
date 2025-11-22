namespace App.Topics.Indexers.T1_2_KeyValueStore;

public class KeyValueStore
{
    private Dictionary<int, string> idDictionary = new Dictionary<int, string>();
    private Dictionary<string, string> keyDictionary = new Dictionary<string, string>();

    public string this[int id]
    {
        get
        {
            if (!idDictionary.ContainsKey(id))
                throw new KeyNotFoundException($"ID {id} не найден.");
            return idDictionary[id];
        }
        set
        {
            idDictionary[id] = value;
        }
    }

    public string this[string key]
    {
        get
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            if (!keyDictionary.ContainsKey(key))
                throw new KeyNotFoundException($"Ключ '{key}' не найден.");
            return keyDictionary[key];
        }
        set
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            keyDictionary[key] = value;
        }
    }
}
