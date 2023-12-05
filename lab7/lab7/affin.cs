using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab7
{
    public partial class Form1
    {
        Axis current_axis;

        //масштабирование
        void scale(ref Polyhedrons polyh, double x_, double y_, double z_)
        {
            Matrix scale_ = new Matrix(4, 4).fillWithElements(x_, 0, 0, 0, 0, y_, 0, 0, 0, 0, z_, 0, 0, 0, 0, 1);
            foreach(var edge in polyh.edges)
            {
                foreach(var line in edge.lines)
                {
                    var p1 = line.leftP;
                    var p2 = line.rightP;
                    var temp_p1 = scale_ * new Matrix(4, 1).fillWithElements(p1.getDoubleX, p1.getDoubleY, p1.getDoubleZ, 1);
                    var temp_p2 = scale_ * new Matrix(4, 1).fillWithElements(p2.getDoubleX, p2.getDoubleY, p2.getDoubleZ, 1);
                    line.leftP = new Points(temp_p1[0, 0], temp_p1[1, 0], temp_p1[2, 0]);
                    line.rightP = new Points(temp_p2[0, 0], temp_p2[1, 0], temp_p2[2, 0]);
                }
            }
        }

        //смещение
        void shift(ref Polyhedrons polyh, double x_, double y_, double z_)
        {
            Matrix shift_ = new Matrix(4, 4).fillWithElements(1, 0, 0, x_, 0, 1, 0, y_, 0, 0, 1, z_, 0, 0, 0, 1);
            foreach (var edge in polyh.edges)
            {
                foreach (var line in edge.lines)
                {
                    var p1 = line.leftP;
                    var p2 = line.rightP;
                    var temp_p1 = shift_ * new Matrix(4, 1).fillWithElements(p1.getDoubleX, p1.getDoubleY, p1.getDoubleZ, 1);
                    var temp_p2 = shift_ * new Matrix(4, 1).fillWithElements(p2.getDoubleX, p2.getDoubleY, p2.getDoubleZ, 1);
                    line.leftP = new Points(temp_p1[0, 0], temp_p1[1, 0], temp_p1[2, 0]);
                    line.rightP = new Points(temp_p2[0, 0], temp_p2[1, 0], temp_p2[2, 0]);
                }
            }
        }

        //поворот
        void rotate(ref Polyhedrons polyh, Axis ax, double angle)
        {
            angle = Math.PI * angle / 180.0;
            Matrix rotate_ = new Matrix(0, 0);
            if(ax == Axis.X)
            {
                rotate_ = new Matrix(4, 4).fillWithElements(1,0,0,0,0, Math.Cos(angle), -Math.Sin(angle),0,0,Math.Sin(angle),Math.Cos(angle),0,0,0,0,1);
            }else if(ax == Axis.Y)
            {
                rotate_ = new Matrix(4, 4).fillWithElements(Math.Cos(angle),0,Math.Sin(angle),0,0,1,0,0,-Math.Sin(angle),0,Math.Cos(angle),0,0,0,0,1);
            }else if(ax == Axis.Z)
            {
                rotate_ = new Matrix(4, 4).fillWithElements(Math.Cos(angle), -Math.Sin(angle),0,0,Math.Sin(angle),Math.Cos(angle),0,0,0,0,1,0,0,0,0,1);
            }
            foreach (var edge in polyh.edges)
            {
                foreach (var line in edge.lines)
                {
                    var p1 = line.leftP;
                    var p2 = line.rightP;
                    var temp_p1 = rotate_ * new Matrix(4, 1).fillWithElements(p1.getDoubleX, p1.getDoubleY, p1.getDoubleZ, 1);
                    var temp_p2 = rotate_ * new Matrix(4, 1).fillWithElements(p2.getDoubleX, p2.getDoubleY, p2.getDoubleZ, 1);
                    line.leftP = new Points(temp_p1[0, 0], temp_p1[1, 0], temp_p1[2, 0]);
                    line.rightP = new Points(temp_p2[0, 0], temp_p2[1, 0], temp_p2[2, 0]);
                }
            }
        }

    };
}
