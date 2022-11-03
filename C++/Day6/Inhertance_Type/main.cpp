#include <iostream>

using namespace std;

class Base{

    protected:
        int y;

    public:
        int z;

        Base(int X, int Y , int Z){x=X ; y=Y ; z=Z;}
        Base(){x=0 ; y=0; z=0; cout << "Base Cons \n" ;}
        ~Base(){cout << "Base Des \n" ;}


         int test(){
            /// All members in class can be accessed
            return x;
            return y;
            return z;

        }
};

class BaseChild:public Base{
    int a;

    protected:
        int b;

    public:
        int c;

        BaseChild(int A , int B , int C , int X, int Y , int Z):
        Base(X,Y,Z){a=A ; b=B ; z=Z;}

        BaseChild(){a=0 ; b=0 ; c=0 ;cout << "BaseChild Cons \n" ;}
        ~BaseChild(){cout << "BaseChild Des \n" ;}

        int test(){
            /// All members in class can be accessed
            return a;
            return b;
            return c;

            /* Start Class Parent */
            return x;
            /// private member can't access outside class

            return y;
            /// in public                   ==> protected member can access
            /// in protected                ==> protected member can access
            /// in private                  ==> protected member can access [protected => shrink to private]
            ///                             ==> but another classes inhereted from it can't

            return z;
            /// in public                   ==> can access
            /// in protected                ==> Public member can access [public => shrink to protected]
            /// in private                  ==> Public member can access [public => shrink to private]
            ///                             ==> but another classes inhereted from it can't

            /* end Class Parent */

        }
};

class Child:public BaseChild{
    int k;

    protected:
        int l;

    public:
        int m;

        Child(int K , int L , int M ,int A , int B , int C , int X, int Y , int Z)
        :BaseChild(A , B , C , X, Y ,Z)
        {k=K ; l=L ; m=M;}

        Child(){k=0 ; l=0 ; m=0 ; cout << "BaseChild Cons \n" ;}
        ~Child(){cout << "BaseChild Des \n" ;}

         int test(){
            /// All members in class can be accessed
            return k;
            return l;
            return m;


            /* start class Base Child */
            return a;
            /// private member can't be accessed in child class

            return b;
            /// in public                   ==> can be accessed
            /// in protected                ==> protected member can be accessed
            /// in private                  ==> protected member can be accessed [protected => shrink to private]
            ///                             ==> but another classes inhereted from it can't

            return c;
            /// in public                   ==> can be accessed
            /// in protected                ==> Public member can be accessed [public => shrink to protected]
            /// in private                  ==> Public member can be accessed [public => shrink to private]
            ///                             ==> but another classes inhereted from it can't


            /* end class Base Child */



           /* Start Class Base  */
            return x;
            /// private member can't be accessed outside class

            return y;
            /// in public                   ==> can be accessed
            /// in protected                ==> protected member can be accessed
            /// in private                  ==> protected member can be accessed [protected => shrink to private]
            ///                             ==> but another classes inhereted from it can't

            return z;
            /// in public                   ==> can access
            /// in protected                ==> Public member can be accessed [public => shrink to protected]
            /// in private                  ==> Public member can be accessed [public => shrink to private]
            ///                             ==> but another classes inhereted from it can't

            /* end Class Base */

        }
};

int main()
{
    cout << "Inhertance Types" << endl;

    /// Public - Public
    Base b(1 , 2 , 3 );
    BaseChild bc(4 , 5 , 6 );
    Child c(7 , 8 , 9 );


    ///b.x = 5;    /// private member can't be accessed
    b.y = 5;       /// protected member can't be accessed in main
    b.z = 5;       /// public member can be accessed

    ///////////////////////////////////////////////////////////

    bc.x = 5;   /// private member can't be accessed
    bc.y = 5;   /// protected member can't be accessed in main
    bc.z = 5;
    /// in private    ==> can't be accessed
    /// in protected  ==> can't be accessed
    /// in public     ==> can be accessed


    bc.a = 5;   /// private member can't be accessed
    bc.b = 5;   /// protected member can't be accessed in main
    bc.c = 5;
    ///  in public                      ==> public member  can be accessed
    ///  in protected                   ==> public member  can't be accessed
    ///  in private                     ==> public member  can't be accessed


    ///////////////////////////////////////////////////////////

    /// [Members in Parent class]

    c.x = 5;   /// private member can't be accessed
    c.y = 5;   /// protected member can't be accessed in main
    c.z = 5;
    /// in public - public    ``          ==> can be accessed
    /// in public - protected             ==> can't be accessed [shrink to protected]
    /// in public - private               ==> can't be accessed [shrink to private]

    /// in protected - public             ==> can't be accessed
    /// in protected - protected          ==> can't be accessed
    /// in protected - private            ==> can't be accessed

    /// in private - public               ==> can't be accessed
    /// in private - protected            ==> can't be accessed
    /// in private - private              ==> can't be accessed


    /// [Members in Base Child class]
    c.a = 5;   /// private member can't be accessed
    c.b = 5;  /// protected member can't be accessed in main
    c.c = 5;
    /// in public(b-bc) - public(bc-c)    ==> can be accessed
    /// in public - protected             ==> can't be accessed [shrink to protected] in main
    /// in public - private               ==> can't be accessed [shrink to private]   in main

    /// in protected - public             ==> can be accessed
    /// in protected - protected          ==> can't be accessed [shrink to protected] in main
    /// in protected - private            ==> can't be accessed [shrink to private] in main

    /// in private - public               ==> can be accessed
    /// in private - protected            ==> can't be accessed
    /// in private - private              ==> can't be accessed



    c.k = 5;   /// private member can't be accessed
    c.l = 5;   /// protected member can't be accessed in main
    c.m = 5;   /// Public member can be accessed


    return 0;
}
