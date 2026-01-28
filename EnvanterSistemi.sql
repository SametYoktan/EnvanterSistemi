-- Veritabaný Oluþturma
CREATE DATABASE EnvanterSistemi;

USE EnvanterSistemi;

-- Kategoriler Tablosu
CREATE TABLE Kategoriler (
    KategoriID INT IDENTITY(1,1) PRIMARY KEY,
    KategoriAdi VARCHAR(255) NOT NULL
);

-- Tedarikçiler Tablosu
CREATE TABLE Tedarikciler (
    TedarikciID INT IDENTITY(1,1) PRIMARY KEY,
    FirmaAdi VARCHAR(255) NOT NULL,
    Telefon VARCHAR(20),
    Adres TEXT
);

-- Ürünler Tablosu
CREATE TABLE Urunler (
    UrunID INT IDENTITY(1,1) PRIMARY KEY,
    UrunAdi VARCHAR(255) NOT NULL,
    Aciklama TEXT,
    Fiyat DECIMAL(10, 2) NOT NULL,
	AktifMi BIT NOT NULL DEFAULT 1,
    StokMiktari INT NOT NULL,
    KategoriID INT NULL,
    TedarikciID INT NULL,
    CONSTRAINT FK_Urunler_Kategori FOREIGN KEY (KategoriID) REFERENCES Kategoriler(KategoriID) ON DELETE SET NULL,
    CONSTRAINT FK_Urunler_Tedarikci FOREIGN KEY (TedarikciID) REFERENCES Tedarikciler(TedarikciID) ON DELETE SET NULL
);

-- Sipariþler Tablosu
CREATE TABLE Siparisler (
    SiparisID INT IDENTITY(1,1) PRIMARY KEY,
    MusteriAdi VARCHAR(255) NOT NULL,
    SiparisTarihi DATETIME DEFAULT GETDATE()
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
INSERT INTO Kategoriler (KategoriAdi)
VALUES 
    ('Elektronik'),
    ('Giyim'),
    ('Yiyecek');

-- Tedarikçiler Tablosuna Örnek Veri
INSERT INTO Tedarikciler (FirmaAdi, Telefon, Adres)
VALUES 
    ('TeknoShop', '5551234567', 'Ýstanbul, Türkiye'),
    ('ModaTedarik', '5559876543', 'Ankara, Türkiye');

-- Ürünler Tablosuna Örnek Veri
INSERT INTO Urunler (UrunAdi, Aciklama, Fiyat, StokMiktari, KategoriID, TedarikciID)
VALUES 
    ('Telefon', 'Akýllý telefon, 128GB hafýza', 2999.99, 50, 1, 1),
    ('Pantolon', 'Kot pantolon, M beden', 149.99, 200, 2, 2),
    ('Süt', '1 litre taze süt', 7.50, 300, 3, 2);

-- Sipariþler Tablosuna Örnek Veri
INSERT INTO Siparisler (MusteriAdi)
VALUES 
    ('Ali Veli'),
    ('Ayþe Yýlmaz'),
    ('Mehmet Kaya');

-- Sipariþ Detaylarý Tablosuna Örnek Veri
INSERT INTO SiparisDetaylar (SiparisID, UrunID, Adet, Fiyat)
VALUES
    (1, 4, 2, 2999.99),
    (2, 5, 3, 149.99),
    (3, 6, 1, 7.50);

-- Tablo Verilerini Görüntüleme
SELECT * FROM Kategoriler;
SELECT * FROM Tedarikciler;
SELECT * FROM Urunler;
SELECT * FROM Siparisler;
SELECT * FROM SiparisDetaylar;
