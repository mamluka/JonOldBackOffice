Public Class DataDec
    Private diamdata As WordLine.StrArr
    Private diamfield As WordLine.StrArr
    Private diambase As WordLine.StrArr
    Private gemdata As WordLine.StrArr
    Private gemfield As WordLine.StrArr
    Private gembase As WordLine.StrArr
    Private jewdata As WordLine.StrArr
    Private jewfield As WordLine.StrArr
    Private jewbase As WordLine.StrArr
    Private custom As WordLine.StrArr
    Private customname As WordLine.StrArr

    Public ReadOnly Property diamsdata() As WordLine.StrArr
        Get
            Return diamdata
        End Get
    End Property

    Public ReadOnly Property diamsfield() As WordLine.StrArr
        Get
            Return diamfield
        End Get
    End Property

    Public ReadOnly Property diamsbase() As WordLine.StrArr
        Get
            Return diambase
        End Get
    End Property

    Public ReadOnly Property gemsdata() As WordLine.StrArr
        Get
            Return gemdata
        End Get
    End Property

    Public ReadOnly Property gemsfield() As WordLine.StrArr
        Get
            Return gemfield
        End Get
    End Property

    Public ReadOnly Property gemsbase() As WordLine.StrArr
        Get
            Return gembase
        End Get
    End Property

    Public ReadOnly Property jewsdata() As WordLine.StrArr
        Get
            Return jewdata
        End Get
    End Property

    Public ReadOnly Property jewsfield() As WordLine.StrArr
        Get
            Return jewfield
        End Get
    End Property

    Public ReadOnly Property jewsbase() As WordLine.StrArr
        Get
            Return jewbase
        End Get
    End Property

    Public ReadOnly Property customs() As WordLine.StrArr
        Get
            Return custom
        End Get
    End Property

    Public ReadOnly Property customsname() As WordLine.StrArr
        Get
            Return customname
        End Get
    End Property

    Public Sub New(ByVal data As WordLine.DataFields)
        '
        diamdata = New WordLine.StrArr(GetType(WordLine.StrArr), 5)
        diamdata.ar.SetValue(data.colors_diam, 0)
        diamdata.ar.SetValue(data.shape_diams, 1)
        diamdata.ar.SetValue(data.stonetype_diams, 2)
        diamdata.ar.SetValue(data.clarity_diams, 3)
        diamdata.ar.SetValue(data.weights, 4)
        '
        diamfield = New WordLine.StrArr(5)
        diamfield.ar.SetValue("color", 0)
        diamfield.ar.SetValue("shape", 1)
        diamfield.ar.SetValue("stonetype", 2)
        diamfield.ar.SetValue("clarity", 3)
        diamfield.ar.SetValue("weight", 4)
        '
        diambase = New WordLine.StrArr(GetType(WordLine.StrArr), 5)
        diambase.ar.SetValue(data.colors_diam_base, 0)
        diambase.ar.SetValue(data.shape_diams_base, 1)
        diambase.ar.SetValue(data.stonetype_diams_base, 2)
        diambase.ar.SetValue(data.clarity_diams_base, 3)
        diambase.ar.SetValue(data.weights_base, 4)
        '
        gemdata = New WordLine.StrArr(GetType(WordLine.StrArr), 5)
        gemdata.ar.SetValue(data.colors_gem, 0)
        gemdata.ar.SetValue(data.origin_gems, 1)
        gemdata.ar.SetValue(data.shape_gems, 2)
        gemdata.ar.SetValue(data.stonetype_gems, 3)
        gemdata.ar.SetValue(data.weights, 4)
        '
        gemfield = New WordLine.StrArr(5)
        gemfield.ar.SetValue("color", 0)
        gemfield.ar.SetValue("origin", 1)
        gemfield.ar.SetValue("shape", 2)
        gemfield.ar.SetValue("stonetype", 3)
        gemfield.ar.SetValue("weight", 4)
        '
        '
        gembase = New WordLine.StrArr(GetType(WordLine.StrArr), 5)
        gembase.ar.SetValue(data.colors_gem_base, 0)
        gembase.ar.SetValue(data.origin_gems_base, 1)
        gembase.ar.SetValue(data.shape_gems_base, 2)
        gembase.ar.SetValue(data.stonetype_gems_base, 3)
        gembase.ar.SetValue(data.weights_base, 4)
        '
        jewdata = New WordLine.StrArr(GetType(WordLine.StrArr), 10)
        jewdata.ar.SetValue(data.jeweltype_jewels, 0)
        jewdata.ar.SetValue(data.jewelsubtype_jewels, 1)
        jewdata.ar.SetValue(data.metal_jewels, 2)
        jewdata.ar.SetValue(data.shape_diams, 3)
        jewdata.ar.SetValue(data.shape_gems, 4)
        jewdata.ar.SetValue(data.stonetype_gems, 5)
        jewdata.ar.SetValue(data.stonetype_diams, 6)
        jewdata.ar.SetValue(data.clarity_diams, 7)
        jewdata.ar.SetValue(data.colors_diam, 8)
        jewdata.ar.SetValue(data.colors_gem, 9)
        '        jewdata.ar.SetValue(data.weights, 10)
        '
        jewfield = New WordLine.StrArr(10)
        jewfield.ar.SetValue("jeweltype", 0)
        jewfield.ar.SetValue("jewelsubtype", 1)
        jewfield.ar.SetValue("metal", 2)
        jewfield.ar.SetValue("stone", 3)
        jewfield.ar.SetValue("stone", 4)
        jewfield.ar.SetValue("stone", 5)
        jewfield.ar.SetValue("stone", 6)
        jewfield.ar.SetValue("stone", 7)
        jewfield.ar.SetValue("stone", 8)
        jewfield.ar.SetValue("stone", 9)
        '       jewfield.ar.SetValue("weight", 10)
        '
        jewbase = New WordLine.StrArr(GetType(WordLine.StrArr), 10)
        jewbase.ar.SetValue(data.jeweltype_jewels_base, 0)
        jewbase.ar.SetValue(data.jewelsubtype_jewels_base, 1)
        jewbase.ar.SetValue(data.metal_jewels_base, 2)
        jewbase.ar.SetValue(data.shape_diams_base, 3)
        jewbase.ar.SetValue(data.shape_gems_base, 4)
        jewbase.ar.SetValue(data.stonetype_gems_base, 5)
        jewbase.ar.SetValue(data.stonetype_diams_base, 6)
        jewbase.ar.SetValue(data.clarity_diams_base, 7)
        jewbase.ar.SetValue(data.colors_diam_base, 8)
        jewbase.ar.SetValue(data.colors_gem_base, 9)
        '       jewbase.ar.SetValue(data.weights_base, 10)
        '
        custom = New WordLine.StrArr(GetType(String), 3)
        custom.ar.SetValue("select ID from inv_jewelry", 0)
        custom.ar.SetValue("select weight from inv_gemstones", 1)
        custom.ar.SetValue("select sell_price from inv_inventory where id<'3000'", 2)
        '
        customname = New WordLine.StrArr(GetType(String), 3)
        customname.ar.SetValue("David", 0)
        customname.ar.SetValue("Avi", 1)
        customname.ar.SetValue("price", 2)
        '
    End Sub

    Protected Overrides Sub Finalize()
        diamdata = Nothing
        diamfield = Nothing
        diambase = Nothing
        gemdata = Nothing
        gemfield = Nothing
        gembase = Nothing
        jewdata = Nothing
        jewfield = Nothing
        jewbase = Nothing
        custom = Nothing
        MyBase.Finalize()
    End Sub

End Class
