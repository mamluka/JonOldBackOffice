if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[JEWVIEW]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[JEWVIEW]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE VIEW dbo.JEWVIEW
AS
SELECT     dbo.inv_JEWELRY.INVENTORY_ID AS ID, dbo.inv_JEWELRY.WEIGHT, dbo.inv_JEWELTYPE_JEWEL.LANG1_SHORTDESCR AS JEWELTYPE, 
                      dbo.inv_JEWELSUBTYPE_JEWEL.LANG1_SHORTDESCR AS JEWELSUBTYPE, dbo.inv_METAL_JEWEL.LANG1_SHORTDESCR AS METAL, 
                      dbo.inv_JEWELRY.stone_extended AS STONE, dbo.inv_CATEGORIES.LANG1_SHORTDESCR AS CATEGORIES, 
                      dbo.inv_SUBCATEGORIES.LANG1_SHORTDESCR AS SUBCATEGORIES
FROM         dbo.inv_JEWELRY INNER JOIN
                      dbo.inv_BRAND_JEWEL ON dbo.inv_JEWELRY.BRAND_ID = dbo.inv_BRAND_JEWEL.ID INNER JOIN
                      dbo.inv_JEWELTYPE_JEWEL ON dbo.inv_JEWELRY.JEWELTYPE_ID = dbo.inv_JEWELTYPE_JEWEL.ID INNER JOIN
                      dbo.inv_JEWELSUBTYPE_JEWEL ON dbo.inv_JEWELRY.JEWELSUBTYPE_ID = dbo.inv_JEWELSUBTYPE_JEWEL.ID INNER JOIN
                      dbo.inv_METAL_JEWEL ON dbo.inv_JEWELRY.METAL_ID = dbo.inv_METAL_JEWEL.ID INNER JOIN
                      dbo.inv_MIDDLESTONE_JEWEL ON dbo.inv_JEWELRY.MIDDLESTONE_ID = dbo.inv_MIDDLESTONE_JEWEL.ID INNER JOIN
                      dbo.inv_INVENTORY ON dbo.inv_JEWELRY.INVENTORY_ID = dbo.inv_INVENTORY.ID INNER JOIN
                      dbo.inv_CATEGORIES ON dbo.inv_INVENTORY.CATEGORY_ID = dbo.inv_CATEGORIES.ID INNER JOIN
                      dbo.inv_SUBCATEGORIES ON dbo.inv_INVENTORY.SUBCATEGORY_ID = dbo.inv_SUBCATEGORIES.ID

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

