printf "\033c" 
while true 
do 
echo 'Меню:' 
echo '1. Информация о программе;' 
echo '2. Вычисление математического выражения;' 
echo '3. Архивирование папки с копированием архива в папку "/tmp/backup"' 
echo '4. В папке вывести все файлы с длиной имени больше заданного значения' 
echo '0. Выход.' 

read menu 

case $menu in 

1)
printf "\033c" 
echo "Суховенко Эдуард Сергеевич, ИП-32." 
echo "А) Архивирование папки с копированием архива в папку '/tmp/backup'"
echo "Б) В папке вывести все файлы с длиной имени больше заданного значения" 
;;

2) 
printf "\033c" 
echo 'Введите A:' 
read A
echo 'Введите B:' 
read B 
echo 'Введите C:' 
read C 
echo 'Результат: ' $(($A * $A + 3 * $B - $C / 2))
;;

3) 
printf "\033c" 
echo 'Введите путь, к папке для архивирования:' 
read path 
echo 'Введите имя архива:' 
read filename
zip -r $filename $path
mkdir /tmp/backup
cp -a $filename "/tmp/backup/$filename"
;;

4)
cd files 
printf "\033c" 
echo 'Введите длину имени файла:' 
read length 
length=$((length+2))
find -regextype egrep -regex "^.{1,$length}\.txt$"
;;

0) exit
esac 
done
