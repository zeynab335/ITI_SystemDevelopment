#ifndef POINT_H
#define POINT_H


class Point
{
    int x;
    int y;

    public:
        Point();
        Point(int , int);

        ~Point();
        setWidth(int);
        setHeight(int);
        getWidth();
        getHeight();
        void show();

    protected:

    private:
};

#endif // POINT_H
