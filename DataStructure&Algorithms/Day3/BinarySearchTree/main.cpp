#include <iostream>
#include <stdlib.h>

using namespace std;

class Node{
    public:
        int key;
        Node *pLeft = NULL;
        Node *pRight = NULL;
};

Node *pTree = NULL;

void DeleteNode(Node * &pRoot);

Node * SearchBTree(Node *pRoot , int key ){
    if(pRoot != NULL) /// in this case tree not empty
    {
        if(pRoot->key == key) return pRoot;
        else if(pRoot->key > key) /// go to left
            return SearchBTree(pRoot->pLeft , key );
        else
            return SearchBTree(pRoot->pRight , key );
    }
    return NULL;  // empty tree
}


/// countNodes
/// count all Right Nodes and Left Nodes + 1==> Root
int countNodes(Node *pRoot){
    if(pRoot != NULL)
        return countNodes(pRoot->pLeft) + 1 + countNodes(pRoot->pRight);
    return 0;
}


/// TreeTraverse Asc
void TreeTraverseAsc(Node *pRoot){
    if(pRoot != NULL){
        /// left
        TreeTraverseAsc(pRoot->pLeft);
        /// Root
        cout << pRoot->key << endl;
        /// right
        TreeTraverseAsc(pRoot->pRight);
    }
}

/// TreeTraverse Desc

void TreeTraverseDesc(Node *pRoot){
    if(pRoot != NULL){
        /// right
        TreeTraverseAsc(pRoot->pRight);
        /// Root
        cout << pRoot->key << endl;
        /// left
        TreeTraverseAsc(pRoot->pLeft);
    }
}

Node * NewNode(){

    Node *pNew = new Node();

    if(pNew==NULL) exit(0);

    pNew->pLeft = pNew->pRight = NULL;

    cout << "Enter new Key:\n" ;
    cin >> pNew->key;

    return pNew;
}

 void InsertNewNode(Node * &pRoot , Node *pNew) {
    if(pRoot ==NULL){
        pRoot = pNew;
    }
    else if(pRoot->key > pNew->key){  /// go to left
        InsertNewNode(pRoot->pLeft , pNew );
    }
    else InsertNewNode(pRoot->pRight , pNew );
 }

 /// insert version 2
  void InsertNewNode(Node * pRoot , Node * pLeaf, Node *pNew) {
    if(pLeaf == NULL){ /// use pRoot to add new node

        if(pRoot ==NULL){ /// Empty tree
            pRoot = pNew;
        }
        else if(pRoot->key > pNew->key){  /// go to left
            InsertNewNode(pRoot->pLeft , pNew );
        }
        else InsertNewNode(pRoot->pRight , pNew );
    }

    else if (pNew->key < pLeaf->key){
        InsertNewNode(pLeaf , pLeaf->pLeft , pNew );
    }
    else{
        InsertNewNode(pLeaf , pLeaf->pRight , pNew );
    }
}

int GetMaxNodes(Node * pRoot){
    /// pRoot->pRight always be max
    while(pRoot->pRight !=NULL )
        pRoot = pRoot->pRight;

    return pRoot->key;
}


/// delete node
void Delete(Node* &pRoot , int key){
    if(key < pRoot->key)
        Delete(pRoot->pLeft , key);

    else if(key > pRoot->key)
        Delete(pRoot->pRight , key);

    else
        DeleteNode(pRoot);
}

void DeleteNode(Node * &pRoot){
    Node *pDelete = pRoot;

    if(pRoot->pLeft == NULL){
        pRoot = pRoot->pRight;
        delete pDelete;
    }
    else if(pRoot->pRight == NULL){
        pRoot = pRoot->pLeft;
        delete pDelete;
    }
    else {
        /// delete root node
        int tempKey = GetMaxNodes(pRoot->pLeft);  /// get max from left
        pRoot->key = tempKey;
        /// delete redundant key
        Delete(pRoot->pLeft , tempKey);
    }
}


int main()
{
    int SearchNum ;
    for(int i=0 ; i<5 ; i++){
        InsertNewNode(pTree , NewNode());
    }
    cout << "Traverse Tree in ASC Way \n" ;
    TreeTraverseAsc(pTree);

    //cout << "\nTraverse Tree in DESC Way \n" ;
    //TreeTraverseDesc(pTree);


    cout << "\ Enter Key to Search it in Tree \n" ;
    cin >> SearchNum;

    Node *pSearch = SearchBTree(pTree , SearchNum);
    if(pSearch !=NULL) cout  << "Found \n";
    else cout  << "Not Found!! \n";

    cout << "\nCountNodes = " ;
    cout << countNodes(pTree) << endl;


    Delete(pTree,4);

    cout << "Traverse Tree after Deleting one node  \n" ;
    TreeTraverseAsc(pTree);


    return 0;
}
