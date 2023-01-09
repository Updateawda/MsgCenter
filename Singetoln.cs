using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 单例模式
{
    /// <summary>
    /// 懒汉式双重锁模式的单例
    /// </summary>
    class Singetoln
    {
        //所有的引用数据类型的默认值是null
        private static   Singetoln instance;
        private static  readonly Object obj=new Object();

        /// <summary>
        /// 1\私有构造，防止在类外被创建多个对象
        /// 一旦私有，类外一个对象也创建不了，只能在类内创建对象
        /// </summary>
        private Singetoln() {

        }
        /// <summary>
        /// 静态的方法只能访问静态的成员
        /// 2、类内创建一个返回该对象的方法
        /// 这个方法设置成公开的静态的
        /// </summary>
        /// <returns></returns>
        public static   Singetoln GetSingetoln() {
            //为了防止无畏的等待
            if (instance == null) {

                //为了防止多个线程同时访问代码块创建多个对象，加把锁,
                //其他线程在外面排队等待
                lock (obj)
                {
                    //如果对象没有被创建过
                    if (instance == null)
                    {
                        instance = new Singetoln();
                    }
                }
            }
          
           //如果创建过该对象，就直接返回
            return instance;
        }

    }
}
