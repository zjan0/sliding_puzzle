# project_9,16
MainWindow.xaml:
tri gridy:intro,PanelF,Ending
intro:uzivatel zada velikost gridu 2-10 a spusti hru
panelf:vygeneruje grid podle zadani uzivatele a hra zacne
ending:hra je ukoncena a uzivatel uvidi sve skore a muze zacit novou hru(presunuti na intro)
mainwindow.xaml.cs:
int score pocita pocet tahu
button_click:aktivuje se kdyz uzivatel klikne na start
start_click:kontroluje jestli je zadana hodnota spravne
generate: generuje grid plny button a naplni je cisly
shuffle: promicha grid tak aby nebyly v originalni pozici a pak zkontroluje ze promichana verze neni reseni
move:prohrazuje button podle toho kam uzivatel klika,pricte pocet tahu a po kazdem uspesnem kliku kontroluje
check:kontroluje jestli je hra vyresena nebo ne (nefunguje)
again_click:aktivuje se kdyz uzivatel klikne na again
newagain:skryje vsechny casti krome intro a vyresetuje vse
