using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using GameClub.GUI.ViewInterfaces;

namespace GameClub.GUI.Views
{
    /// <summary>
    /// Главная форма приложения - карта компьютерного клуба
    /// Отображает 35 мест и панель управления
    /// </summary>
    public partial class MainForm : Form, IMainView
    {
        /// <summary>
        /// Таймер автоматического обновления карты мест (раз в минуту)
        /// </summary>
        private System.Windows.Forms.Timer timer;

        /// <summary>
        /// Событие обновления карты мест
        /// </summary>
        public event EventHandler RefreshRequested;

        /// <summary>
        /// Событие поиска свободного места
        /// </summary>
        public event EventHandler FindFreeSeatRequested;

        /// <summary>
        /// Событие закрытия активной сессии
        /// </summary>
        public event EventHandler CloseSessionRequested;

        /// <summary>
        /// Событие добавления часов к сессии
        /// </summary>
        public event EventHandler AddHoursRequested;

        /// <summary>
        /// Событие просмотра выручки
        /// </summary>
        public event EventHandler RevenueRequested;

        /// <summary>
        /// Событие открытия панели администратора (настройка тарифов)
        /// </summary>
        public event EventHandler AdminPanelRequested;

        /// <summary>
        /// Событие управления операторами
        /// </summary>
        public event EventHandler ManageOperatorsRequested;

        /// <summary>
        /// Событие нажатия на кнопку места на карте.
        /// Параметр — ID выбранного места.
        /// </summary>
        public event EventHandler<int> SeatButtonClicked;

        /// <summary>
        /// Конструктор формы
        /// </summary>
        public MainForm()
        {
            Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            AutoScaleMode = AutoScaleMode.Dpi;
            InitializeComponent();
            MinimumSize = new Size(1305, 740);

            btnRefresh.Click += (s, e) => RefreshRequested?.Invoke(this, EventArgs.Empty);
            btnFindFreeSeat.Click += (s, e) => FindFreeSeatRequested?.Invoke(this, EventArgs.Empty);
            btnCloseSession.Click += (s, e) => CloseSessionRequested?.Invoke(this, EventArgs.Empty);
            btnAddHours.Click += (s, e) => AddHoursRequested?.Invoke(this, EventArgs.Empty);
            btnRevenue.Click += (s, e) => RevenueRequested?.Invoke(this, EventArgs.Empty);
            btnAdminPanel.Click += (s, e) => AdminPanelRequested?.Invoke(this, EventArgs.Empty);
            btnManageOperators.Click += (s, e) => ManageOperatorsRequested?.Invoke(this, EventArgs.Empty);

            WireUpSeatButtons();

            timer = new System.Windows.Forms.Timer { Interval = 60000 };
            timer.Tick += (s, e) => RefreshRequested?.Invoke(this, EventArgs.Empty);
            timer.Start();

            FormClosing += (s, e) => { timer.Stop(); timer.Dispose(); };
        }

        /// <summary>
        /// Подписка на клики всех 35 кнопок мест (General + VIP)
        /// </summary>
        private void WireUpSeatButtons()
        {
            var seatButtons = new Button[]
            {
                btnGen1,  btnGen2,  btnGen3,  btnGen4,  btnGen5,
                btnGen6,  btnGen7,  btnGen8,  btnGen9,  btnGen10,
                btnGen11, btnGen12, btnGen13, btnGen14, btnGen15,
                btnGen16, btnGen17, btnGen18, btnGen19, btnGen20,
                btnGen21, btnGen22, btnGen23, btnGen24, btnGen25,
                btnVip1,  btnVip2,  btnVip3,  btnVip4,  btnVip5,
                btnVip6,  btnVip7,  btnVip8,  btnVip9,  btnVip10
            };

            foreach (var btn in seatButtons)
            {
                btn.Click += SeatButton_Click;
            }
        }

        /// <summary>
        /// Обработчик клика по кнопке места.
        /// Извлекает номер ПК из текста кнопки и вызывает событие SeatButtonClicked
        /// </summary>
        private void SeatButton_Click(object sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                var match = Regex.Match(btn.Text, @"\d+");
                if (match.Success)
                    SeatButtonClicked?.Invoke(this, int.Parse(match.Value));
            }
        }

        /// <summary>
        /// Установка заголовка формы
        /// </summary>
        /// <param name="title">Текст заголовка</param>
        public void SetTitle(string title) => Text = title;

        /// <summary>
        /// Отображение или скрытие кнопок администратора
        /// </summary>
        /// <param name="visible">Флаг видимости кнопок</param>
        public void ShowAdminButtons(bool visible)
        {
            btnRevenue.Visible = visible;
            btnAdminPanel.Visible = visible;
            btnManageOperators.Visible = visible;
        }

        /// <summary>
        /// Установка цвета кнопки места на карте
        /// </summary>
        /// <param name="seatId">ID места (1-35)</param>
        /// <param name="color">Цвет кнопки</param>
        public void SetSeatColor(int seatId, Color color)
        {
            var map = new Dictionary<int, Button>
            {
                { 1,  btnGen1  }, { 2,  btnGen2  }, { 3,  btnGen3  }, { 4,  btnGen4  }, { 5,  btnGen5  },
                { 6,  btnGen6  }, { 7,  btnGen7  }, { 8,  btnGen8  }, { 9,  btnGen9  }, { 10, btnGen10 },
                { 11, btnGen11 }, { 12, btnGen12 }, { 13, btnGen13 }, { 14, btnGen14 }, { 15, btnGen15 },
                { 16, btnGen16 }, { 17, btnGen17 }, { 18, btnGen18 }, { 19, btnGen19 }, { 20, btnGen20 },
                { 21, btnGen21 }, { 22, btnGen22 }, { 23, btnGen23 }, { 24, btnGen24 }, { 25, btnGen25 },
                { 26, btnVip1  }, { 27, btnVip2  }, { 28, btnVip3  }, { 29, btnVip4  }, { 30, btnVip5  },
                { 31, btnVip6  }, { 32, btnVip7  }, { 33, btnVip8  }, { 34, btnVip9  }, { 35, btnVip10 }
            };

            if (map.TryGetValue(seatId, out var button))
                button.BackColor = color;
        }

        /// <summary>
        /// Отображение сообщения об ошибке
        /// </summary>
        /// <param name="message">Текст ошибки</param>
        public void ShowError(string message)
        {
            MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Отображение информационного сообщения
        /// </summary>
        /// <param name="message">Текст сообщения</param>
        public void ShowInfo(string message)
        {
            MessageBox.Show(message, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}