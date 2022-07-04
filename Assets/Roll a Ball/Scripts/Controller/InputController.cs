
using UnityEngine;//оставляем только это. Больше нам ничего не понадобится

namespace Maze
{

    public class InputController : IExecute //уберем наследование от монобихэйвиор. Таким образом берем ручное управление
    {
        private readonly Unit _player;//переменная для игрока. Чтобы мы могли понять, кем управляем
                                      //по этой ссылке можем давать игроку управлять кем угодно
        private float horizontal;//заведем переменные для горизонтальных и вертикальных осей
        private float vertical;

        public InputController(Unit player) //создадим конструктор класса. В конструктор будем передавать наш Юнит
        {
            _player = player;//инициализируем ссылку на того персонажа, которым хотим управлять
        }
            


        public void Update()//апдэйт больше на будет вызываться автоматом. мы будем вызывать его сами.Делаем публичным, чтобы могли вызвать в другом месте
        {//получаем наши оси

            horizontal = Input.GetAxis("Horizontal");//подменяем управление осями, если игрок хочет
            vertical = Input.GetAxis("Vertical");
            _player.Move(horizontal, 0f, vertical);//вызываем из плэйера метод Move. В нем определяем переменные
        }
        
    }
    
}
