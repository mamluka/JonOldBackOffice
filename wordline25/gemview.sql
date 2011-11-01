if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[gemVIEW]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[gemVIEW]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE VIEW dbo.gemVIEW
AS
SELECT     dbo.inv_GEMSTONES.INVENTORY_ID AS ID, dbo.inv_COLOR_GEM.LANG1_SHORTDESCR AS COLOR, 
                      dbo.inv_ORIGIN_GEM.LANG1_SHORTDESCR AS ORIGIN, dbo.inv_SHAPE_GEM.LANG1_SHORTDESCR AS SHAPE, 
                      dbo.inv_STONETYPE_GEM.LANG1_SHORTDESCR AS STONETYPE, dbo.inv_GEMSTONES.WEIGHT, dbo.inv_GEMSTONES.MEASURE1, 
                      dbo.inv_GEMSTONES.MEASURE2, dbo.inv_GEMSTONES.MEASURE3, dbo.inv_REPORT_GEM.LANG1_SHORTDESCR AS REPORT, 
                      dbo.inv_SUBCATEGORIES.LANG1_SHORTDESCR AS SUBCATEGORIES, dbo.inv_CATEGORIES.LANG1_SHORTDESCR AS CATEGORIES
FROM         dbo.inv_SUBCATEGORIES INNER JOIN
                      dbo.inv_CATEGORIES INNER JOIN
                      dbo.inv_INVENTORY INNER JOIN
                      dbo.inv_GEMSTONES INNER JOIN
                      dbo.inv_COLOR_GEM ON dbo.inv_GEMSTONES.COLOR_ID = dbo.inv_COLOR_GEM.ID INNER JOIN
                      dbo.inv_COLORTYPE_GEM ON dbo.inv_GEMSTONES.COLORTYPE_ID = dbo.inv_COLORTYPE_GEM.ID INNER JOIN
                      dbo.inv_CUT_GEM ON dbo.inv_GEMSTONES.CUT_ID = dbo.inv_CUT_GEM.ID INNER JOIN
                      dbo.inv_ENHANCEMENT_GEM ON dbo.inv_GEMSTONES.ENHANCEMENT_ID = dbo.inv_ENHANCEMENT_GEM.ID INNER JOIN
                      dbo.inv_GRADE_GEM ON dbo.inv_GEMSTONES.GRADE_ID = dbo.inv_GRADE_GEM.ID INNER JOIN
                      dbo.inv_LUSTER_GEM ON dbo.inv_GEMSTONES.LUSTER_ID = dbo.inv_LUSTER_GEM.ID INNER JOIN
                      dbo.inv_ORIGIN_GEM ON dbo.inv_GEMSTONES.ORIGIN_ID = dbo.inv_ORIGIN_GEM.ID INNER JOIN
                      dbo.inv_SHAPE_GEM ON dbo.inv_GEMSTONES.SHAPE_ID = dbo.inv_SHAPE_GEM.ID INNER JOIN
                      dbo.inv_STONETYPE_GEM ON dbo.inv_GEMSTONES.STONETYPE_ID = dbo.inv_STONETYPE_GEM.ID INNER JOIN
                      dbo.inv_REPORT_GEM ON dbo.inv_GEMSTONES.REPORT_ID = dbo.inv_REPORT_GEM.ID ON 
                      dbo.inv_INVENTORY.ID = dbo.inv_GEMSTONES.INVENTORY_ID ON dbo.inv_CATEGORIES.ID = dbo.inv_INVENTORY.CATEGORY_ID ON 
                      dbo.inv_SUBCATEGORIES.ID = dbo.inv_INVENTORY.SUBCATEGORY_ID

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

