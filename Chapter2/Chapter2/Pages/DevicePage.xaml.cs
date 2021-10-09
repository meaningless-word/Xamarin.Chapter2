﻿using Chapter2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Chapter2.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DevicePage : ContentPage
    {
        public DevicePage()
        {
            InitializeComponent();
            GetDevices();
        }
        
        /// <summary>
        /// Метод для выгрузки устройств
        /// </summary>
        public void GetDevices()
        {
            // Создадим некий список устройств.
            // В реальном приложении они могут доставаться из базы или веб-сервиса
            var homeDevices = new List<HomeDevice>();

            // Заполняем список устройств
            homeDevices.Add(new HomeDevice("Чайник", "kettle.jpg"));
            homeDevices.Add(new HomeDevice("Стиральная машина"));
            homeDevices.Add(new HomeDevice("Посудомоечная машина"));
            homeDevices.Add(new HomeDevice("Мультиварка"));
            homeDevices.Add(new HomeDevice("Водонагреватель"));
            homeDevices.Add(new HomeDevice("Плита"));
            homeDevices.Add(new HomeDevice("Микроволновая печь"));
            homeDevices.Add(new HomeDevice("Духовой шкаф"));
            homeDevices.Add(new HomeDevice("Холодильник"));
            homeDevices.Add(new HomeDevice("Увлажнитель воздуха"));
            homeDevices.Add(new HomeDevice("Телевизор"));
            homeDevices.Add(new HomeDevice("Пылесос"));
            homeDevices.Add(new HomeDevice("музыкальный центр"));
            homeDevices.Add(new HomeDevice("Компьютер"));
            homeDevices.Add(new HomeDevice("Игровая консоль"));

            // Создадим новый стек
            var innerStack = new StackLayout();
            // Сохраним в стек имеющиеся данные, используя свойство Children
            foreach (var homeDevice in homeDevices)
            {
                // Создадим текстовый элемент
                var deviceLabel = new Label() {Text = homeDevice.Name, FontSize = 17};
                // Контейнер rame внутри которого будет отобрадатьсяя текстовый жлемент
                var frame = new Frame()
                {
                    BorderColor = Color.Gray,
                    BackgroundColor = Color.FromHex("#e1e1e1"),
                    CornerRadius = 4,
                    Margin = new Thickness(10, 1)
                };
                // Зададим содержимое контейнера Frame
                frame.Content = deviceLabel;

                // Создаем объект, отвечающий за распознавание нажатий
                var gesture = new TapGestureRecognizer();
                // Устанавливаем по событию нажатия вызов метода ShowImage(...) со ссылкой на изображение в качестве аргумента
                gesture.Tapped += async (sender, e) => await ShowImage(sender, e, homeDevice.Image);
                // Добавляем настроенный распознаватель нажатий в текущий фрейм
                frame.GestureRecognizers.Add(gesture);

                // Добавляем фреймы в стек для их отображения в кдином списке по порядку
                innerStack.Children.Add(frame);
            }
            
            // Сохраним стек внутрь уже имеющегося в xaml-файле блока прокручиваемой разметки
            scrollView.Content = innerStack;
        }

		private async Task ShowImage(object sender, EventArgs e, string imageName)
		{
			// Если избражение отсутствует - покащываем информационное окно
			if (String.IsNullOrEmpty(imageName))
			{
                // Вместо всплывающего окна покажем пользователю картинку из сети, обозначающую, что изображение недоступно
                /*
                await DisplayAlert("", "Изображение устройства отсутствует", "Ok");
                */

                // Создаём новый объект изображения
                Image img = new Image();
                // Подключаем удаленный ресурс в качестве источника изображения
                img.Source = new UriImageSource()
                {
                    CachingEnabled = false,
                    Uri = new Uri("https://i.stack.imgur.com/y9DpT.jpg"),
                };
                // Свойство Aspect отвечает за масштабирование изображения. В данном случае сохранятся пропорции, но «лишняя часть», образовавшаяся при заполнении экрана, будет обрезана
                img.Aspect = Aspect.AspectFill;

                // Инициализируем страницу
                Content = img;

                return;
			}

            // При наличии изображения - загружаем его по заданному пути
            // у изображения свойство Build Action должно быть установлено "Embedded Resource" в менеджере свойств
            Image image = new Image();
            image.Source = ImageSource.FromResource($"Chapter2.Images.{imageName}");
            Content = image;
		}
	}
}