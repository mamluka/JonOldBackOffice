if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[diamview]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[diamview]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE VIEW dbo.diamview
AS
SELECT     dbo.inv_STONETYPE_DIAM.LANG1_SHORTDESCR AS STONETYPE, dbo.inv_COLOR_DIAM.LANG1_SHORTDESCR AS COLOR, 
                      dbo.inv_SHAPE_DIAM.LANG1_SHORTDESCR AS SHAPE, dbo.inv_DIAMONDS.WEIGHT, dbo.inv_DIAMONDS.QUANTITY, 
                      dbo.inv_DIAMONDS.MEASURE1, dbo.inv_DIAMONDS.MEASURE2, dbo.inv_DIAMONDS.MEASURE3, dbo.inv_DIAMONDS.DEPTH, 
                      dbo.inv_DIAMONDS.TABLEWIDTH, dbo.inv_SUBCATEGORIES.LANG1_LONGDESCR AS SUBCATEGORIES, 
                      inv_CLARITY_DIAM_1.LANG1_SHORTDESCR AS CLARITY, dbo.inv_DIAMONDS.INVENTORY_ID AS ID, 
                      dbo.inv_REPORT_DIAM.LANG1_SHORTDESCR AS REPORT
FROM         dbo.inv_DIAMONDS INNER JOIN
                      dbo.inv_COLOR_DIAM ON dbo.inv_DIAMONDS.COLOR_ID = dbo.inv_COLOR_DIAM.ID INNER JOIN
                      dbo.inv_CLARITY_DIAM ON dbo.inv_DIAMONDS.CLARITY_ID = dbo.inv_CLARITY_DIAM.ID INNER JOIN
                      dbo.inv_POLISH_DIAM ON dbo.inv_DIAMONDS.POLISH_ID = dbo.inv_POLISH_DIAM.ID INNER JOIN
                      dbo.inv_SYMMETRY_DIAM ON dbo.inv_DIAMONDS.SYMMETRY_ID = dbo.inv_SYMMETRY_DIAM.ID INNER JOIN
                      dbo.inv_FLUORECENCE_DIAM ON dbo.inv_DIAMONDS.FLUORECENCE_ID = dbo.inv_FLUORECENCE_DIAM.ID INNER JOIN
                      dbo.inv_GIRDLE_DIAM ON dbo.inv_DIAMONDS.GIRDLE_ID = dbo.inv_GIRDLE_DIAM.ID INNER JOIN
                      dbo.inv_CULET_DIAM ON dbo.inv_DIAMONDS.CULET_ID = dbo.inv_CULET_DIAM.ID INNER JOIN
                      dbo.inv_SHAPE_DIAM ON dbo.inv_DIAMONDS.SHAPE_ID = dbo.inv_SHAPE_DIAM.ID INNER JOIN
                      dbo.inv_STONETYPE_DIAM ON dbo.inv_DIAMONDS.STONETYPE_ID = dbo.inv_STONETYPE_DIAM.ID INNER JOIN
                      dbo.inv_REPORT_DIAM ON dbo.inv_DIAMONDS.REPORT_ID = dbo.inv_REPORT_DIAM.ID INNER JOIN
                      dbo.inv_INVENTORY ON dbo.inv_DIAMONDS.INVENTORY_ID = dbo.inv_INVENTORY.ID INNER JOIN
                      dbo.inv_SUBCATEGORIES ON dbo.inv_INVENTORY.SUBCATEGORY_ID = dbo.inv_SUBCATEGORIES.ID INNER JOIN
                      dbo.inv_CATEGORIES ON dbo.inv_INVENTORY.CATEGORY_ID = dbo.inv_CATEGORIES.ID INNER JOIN
                      dbo.inv_CLARITY_DIAM inv_CLARITY_DIAM_1 ON dbo.inv_DIAMONDS.CLARITY_ID = inv_CLARITY_DIAM_1.ID

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

