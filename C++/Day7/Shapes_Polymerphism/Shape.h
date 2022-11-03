#ifndef SHAPE_H
#define SHAPE_H


class Shape
{
    public:
        Shape();
        Shape(int D1 , int D2 );
        virtual ~Shape();

        void setDim1(int);
        void setDim2(int);
        int getDim1();
        int getDim2 ();
        /// Must implemented by inhereted class
        virtual double CalcArea();


    protected:
        int Dim1;
        int Dim2;

    private:
};

#endif // SHAPE_H
