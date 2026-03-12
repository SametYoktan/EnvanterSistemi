-- Veritabaný Oluþturma
CREATE DATABASE EnvanterSistemi;

USE EnvanterSistemi;

-- Kategoriler Tablosu
CREATE TABLE Kategoriler (
    KategoriID INT IDENTITY(1,1) PRIMARY KEY,
    KategoriAdi VARCHAR(255) NOT NULL,
	AktifMi BIT NOT NULL DEFAULT 1
);

-- Tedarikçiler Tablosu
CREATE TABLE Tedarikciler (
    TedarikciID INT IDENTITY(1,1) PRIMARY KEY,
    FirmaAdi VARCHAR(255) NOT NULL,
    Telefon VARCHAR(20),
    Adres TEXT,
	AktifMi BIT NOT NULL DEFAULT 1
);

-- Ürünler Tablosu
CREATE TABLE Urunler (
    UrunID INT IDENTITY(1,1) PRIMARY KEY,
    UrunAdi VARCHAR(255) NOT NULL,
    Aciklama TEXT,
    Fiyat DECIMAL(10, 2) NOT NULL,
    StokMiktari INT NOT NULL,
    KategoriID INT NULL,
    TedarikciID INT NULL,
	AktifMi BIT NOT NULL DEFAULT 1,
    CONSTRAINT FK_Urunler_Kategori FOREIGN KEY (KategoriID) REFERENCES Kategoriler(KategoriID) ON DELETE SET NULL,
    CONSTRAINT FK_Urunler_Tedarikci FOREIGN KEY (TedarikciID) REFERENCES Tedarikciler(TedarikciID) ON DELETE SET NULL
);

-- Sipariþler Tablosu
CREATE TABLE Siparisler (
    SiparisID INT IDENTITY(1,1) PRIMARY KEY,
    MusteriAdi VARCHAR(255) NOT NULL,
	MusteriSoyadi VARCHAR(255) NOT NULL,
    SiparisTarihi DATETIME DEFAULT GETDATE(),
	AktifMi BIT NOT NULL DEFAULT 1
);

-- Sipariþ Detaylarý Tablosu (Bir sipariþ birden fazla ürünü içerebilir)
CREATE TABLE SiparisDetaylar (
    SiparisDetayID INT IDENTITY(1,1) PRIMARY KEY,
    SiparisID INT NOT NULL,
    UrunID INT NULL,
    Adet INT NOT NULL,
    Fiyat DECIMAL(10,2) NOT NULL,
    CONSTRAINT FK_SiparisDetay_Siparis FOREIGN KEY (SiparisID) REFERENCES Siparisler(SiparisID) ON DELETE CASCADE,
    CONSTRAINT FK_SiparisDetay_Urun FOREIGN KEY (UrunID) REFERENCES Urunler(UrunID) ON DELETE SET NULL
);

-- Kategoriler Tablosuna Örnek Veri
INSERT INTO Kategoriler (KategoriAdi) VALUES
('Bilgisayar'),
('Telefon Aksesuarlarý'),
('Ev Elektroniði'),
('Küçük Ev Aletleri'),
('Spor Ürünleri'),
('Ofis Malzemeleri'),
('Oyuncak'),
('Kitap'),
('Kozmetik'),
('Mobilya'),
('Bahçe Ürünleri'),
('Oyun Konsolu'),
('Pet Shop'),
('Bebek Ürünleri'),
('Kýrtasiye'),
('Temizlik Ürünleri'),
('Mutfak Gereçleri'),
('Ayakkabý'),
('Taký'),
('Outdoor Ürünleri');

-- Tedarikçiler Tablosuna Örnek Veri
INSERT INTO Tedarikciler (FirmaAdi, Telefon, Adres) VALUES
('MegaTeknoloji','5551112233','Ýstanbul'),
('Anadolu Elektronik','5552223344','Ankara'),
('Ege Ticaret','5553334455','Ýzmir'),
('Karadeniz Tedarik','5554445566','Trabzon'),
('Akdeniz Pazarlama','5555556677','Antalya'),
('Bursa Ticaret','5556667788','Bursa'),
('TeknoMarket','5557778899','Ýstanbul'),
('Moda Center','5558889900','Ýzmir'),
('EvShop','5559990011','Ankara'),
('Global Tedarik','5551113344','Kocaeli'),
('Hýzlý Lojistik','5552225566','Sakarya'),
('Elite Teknoloji','5553336677','Ýstanbul'),
('Modern Ticaret','5554447788','Eskiþehir'),
('Anka Daðýtým','5555558899','Konya'),
('Atlas Tedarik','5556669900','Adana'),
('Nova Elektronik','5557770011','Gaziantep'),
('Güneþ Pazarlama','5558881122','Antalya'),
('Zenith Ticaret','5559992233','Ýstanbul'),
('Beta Teknoloji','5551114455','Bursa'),
('Delta Tedarik','5552226677','Ýzmir');

-- Ürünler Tablosuna Örnek Veri
INSERT INTO Urunler (UrunAdi,Aciklama,Fiyat,StokMiktari,KategoriID,TedarikciID) VALUES
('Laptop','16GB RAM i7 Laptop',25000,20,4,1),
('Kablosuz Mouse','Logitech Kablosuz Mouse',450,150,1,2),
('Klavye','Mekanik Gaming Klavye',1200,80,1,3),
('Kulaklýk','Bluetooth Kulaklýk',900,100,2,4),
('Tablet','10 inç Android Tablet',8500,40,1,5),
('Akýllý Saat','Su geçirmez smartwatch',3500,60,2,6),
('Televizyon','55 inç Smart TV',18000,25,4,7),
('Elektrikli Süpürge','Torbasýz süpürge',7500,30,4,8),
('Kahve Makinesi','Filtre kahve makinesi',2200,50,4,9),
('Koþu Ayakkabýsý','Erkek spor ayakkabý',1800,90,5,10),
('Ofis Sandalyesi','Ergonomik sandalye',3200,40,6,11),
('Defter','A4 çizgili defter',25,500,16,12),
('Oyuncak Araba','Uzaktan kumandalý',650,70,8,13),
('Roman Kitap','Modern Türk romaný',120,200,9,14),
('Þampuan','Saç bakým þampuaný',95,300,10,15),
('Bahçe Makasý','Profesyonel makas',350,60,12,16),
('PlayStation Kol','PS5 kontrolcü',2800,35,13,17),
('Mama Kabý','Evcil hayvan mama kabý',120,120,14,18),
('Bebek Bezi','Premium paket',450,80,15,19),
('Çadýr','2 kiþilik kamp çadýrý',1900,25,20,20);

-- Sipariþler Tablosuna Örnek Veri
INSERT INTO Siparisler (MusteriAdi,MusteriSoyadi) VALUES
('Ahmet','Demir'),
('Mehmet','Çelik'),
('Ayþe','Kurt'),
('Fatma','Þahin'),
('Hasan','Arslan'),
('Emine','Koç'),
('Hüseyin','Doðan'),
('Zeynep','Kara'),
('Ali','Yýldýz'),
('Merve','Aydýn'),
('Burak','Polat'),
('Elif','Güneþ'),
('Mustafa','Öztürk'),
('Seda','Yalçýn'),
('Okan','Eren'),
('Selin','Tekin'),
('Cem','Bulut'),
('Deniz','Aksoy'),
('Ece','Taþ'),
('Serkan','Kýlýç');

-- Sipariþ Detaylarý Tablosuna Örnek Veri
INSERT INTO SiparisDetaylar (SiparisID,UrunID,Adet,Fiyat) VALUES
(1,1,1,25000),
(1,2,2,450),
(2,3,1,1200),
(2,4,1,900),
(3,5,1,8500),
(4,6,1,3500),
(5,7,1,18000),
(6,8,1,7500),
(7,9,1,2200),
(8,10,2,1800),
(9,11,1,3200),
(10,12,5,25),
(11,13,1,650),
(12,14,2,120),
(13,15,3,95),
(14,16,1,350),
(15,17,1,2800),
(16,18,2,120),
(17,19,1,450),
(18,20,1,1900),
(19,4,1,2000),
(20,5,1,2200);

-- Tablo Verilerini Görüntüleme
SELECT * FROM Kategoriler;
SELECT * FROM Tedarikciler;
SELECT * FROM Urunler;
SELECT * FROM Siparisler;
SELECT * FROM SiparisDetaylar;