SELECT p.Urun,

	(SELECT MIN(S�te)
	FROM Product m
	WHERE m.Fiyat= (SELECT MIN(Fiyat) FROM Product f where f.Urun= p.Urun)) as MinimumFiyatl�Site,

	MIN(Fiyat) as MinimumFiyat,

	(SELECT MAX(S�te) 
	FROM Product x
	WHERE x.Fiyat= (SELECT MAX(Fiyat) FROM Product f where f.Urun = p.Urun)) as MaximumFiyatl�Site,

	MAX(Fiyat) as MaximumFiyat,

	AVG(Fiyat) as OrtalamaFiyat
FROM Product p
Group By p.Urun