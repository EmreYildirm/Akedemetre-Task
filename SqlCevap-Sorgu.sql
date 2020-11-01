SELECT p.Urun,

	(SELECT MIN(Sýte)
	FROM Product m
	WHERE m.Fiyat= (SELECT MIN(Fiyat) FROM Product f where f.Urun= p.Urun)) as MinimumFiyatlýSite,

	MIN(Fiyat) as MinimumFiyat,

	(SELECT MAX(Sýte) 
	FROM Product x
	WHERE x.Fiyat= (SELECT MAX(Fiyat) FROM Product f where f.Urun = p.Urun)) as MaximumFiyatlýSite,

	MAX(Fiyat) as MaximumFiyat,

	AVG(Fiyat) as OrtalamaFiyat
FROM Product p
Group By p.Urun