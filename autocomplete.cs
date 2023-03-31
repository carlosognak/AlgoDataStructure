// Class TrieNode
class TrieNode {
    // Dictionnaire qui stocke les enfants de chaque noeud
    public Dictionary<char, TrieNode> Children;
    public bool IsEnd;
    
    public TrieNode() {
        Children = new Dictionary<char, TrieNode>();
        IsEnd = false;
    }
}

// Class Trie
class Trie {
    private TrieNode root;
    public Trie() {
        root = new TrieNode();
    }

    public void Insert(string word) {
  
        TrieNode curr = root;
        // Parcourt chaque caractère du mot
        foreach (char c in word) {
            // Si le caractère n'a pas encore été ajouté comme enfant, on l'ajoute
            if (!curr.Children.ContainsKey(c)) {
                curr.Children[c] = new TrieNode();
            }
           
            curr = curr.Children[c];
        }
   
        curr.IsEnd = true;
        // On ajoute une étoile (*) à la fin du mot pour marquer la fin du mot
        curr.Children['*'] = new TrieNode();
    }

    public TrieNode Search(string word) {
        TrieNode curr = root;
        foreach (char c in word) {
            // Si le caractère n'a pas encore été ajouté comme enfant, le mot n'est pas présent
            if (!curr.Children.ContainsKey(c)) {
                return null;
            }
            
            curr = curr.Children[c];
        }
        // Retourne le noeud correspondant au dernier caractère du mot
        return curr;
    }

    public List<string> CollectAllWords(TrieNode node = null, string word = "", List<string> words = null) {
        // Initialise les valeurs par défaut pour node, word et words
        if (node == null) {
            node = root;
        }
        if (words == null) {
            words = new List<string>();
        }
        // Si le noeud marque la fin d'un mot, on ajoute le mot à la liste de mots trouvés
        if (node.IsEnd) {
            words.Add(word);
        }
        // On parcourt chaque enfant du noeud
        foreach (KeyValuePair<char, TrieNode> child in node.Children) {
            // On ignore l'étoile (*) ajoutée à la fin des mots pour marquer la fin du mot
            if (child.Key != '*') {
                // On rappelle la fonction CollectAllWords récursivement pour chaque enfant, en passant le mot courant en paramètre
                CollectAllWords(child.Value, word + child.Key, words);
            }
        }
        // On retourne la liste de tous les mots trouvés
        return words;
    }
}
