Imports System.Web
Public Class cls_notes

    Inherits iFoundation.cls_error_connection
    Public _id As Int32
    Public _plate_type As Int16 '' check if jewel
    Public _plate_cat As Int16
    Public _plate_subcat As Int16 ''check inside more
    Public _stone_name As String ''runy sappire etc
    Public _middlestone As String ''
    Public _cut As String
    Public _cut_txt As String
    Public _mounttype As String
    Public _has_report As Boolean
    Public _has_bigpic As Boolean



    Public Function create_note(ByRef outstring As String) As Boolean
        Dim bError As Boolean = False
        Dim linkstr_txt As String
        Dim linkstr As String
        If Me._cut <> "" Then
            Me._cut_txt = Me._cut
            Me._cut = Me._cut.Replace(" ", "%20")
        End If

        If Me._has_bigpic Then
            outstring = "<center><BIG><B><a href=" + HttpContext.Current.Session("user")._domain + "/show-extended/2-" + Convert.ToString(Me._id) + ".htm><font color=black><br><b>3-D MAGNIFIED PICTURES</big></b><br>click Here</a></b></font></center>"
        End If

        If Me._has_report Then
            outstring = outstring + "<center><a href=" + HttpContext.Current.Session("user")._domain + "/show-extended/1-" + Convert.ToString(Me._id) + ".htm><font color=black><br><b><big>INDEPENDENT <BR>CERTIFICATE</big></b><br>click Here</a></b></font></Center>"
        End If



        Select Case _plate_type
            Case 1 ''diamonds
                Select Case Me._plate_cat
                    Case 1 '' normal
                        Select Case Me._plate_subcat
                            Case 1 ''loose
                                linkstr = "/listitem.aspx?mode=1&st=Diamond&sh=" + Me._cut + "%20Cut&r2=0"
                                linkstr_txt = Me._cut_txt + " - Diamonds"
                            Case 2 ''pars
                                Select Case Me._cut_txt
                                    Case "Half Moon shape"
                                        linkstr = "/diamonds/diamond-halfmoon-pairs.aspx"
                                        linkstr_txt = Me._cut_txt + " - Diamonds Pairs"
                                    Case "Heart shape"
                                        linkstr = "/diamonds/diamond-heart-pairs.aspx"
                                        linkstr_txt = Me._cut_txt + " - Diamonds Pairs"
                                    Case "Oval Cut"
                                        linkstr = "/diamonds/diamond-oval-pairs.aspx"
                                        linkstr_txt = Me._cut_txt + " - Diamonds Pairs"
                                    Case "Pear Cut"
                                        linkstr = "/diamonds/diamond-pear-pairs.aspx"
                                        linkstr_txt = Me._cut_txt + " - Diamonds Pairs"
                                    Case "Round bralliant Cut"
                                        linkstr = "/diamonds/diamond-round-brilliant-pairs.aspx"
                                        linkstr_txt = Me._cut_txt + " - Diamonds Pairs"
                                    Case "Trillion Cut"
                                        linkstr = "/diamonds/diamond-trillion-pairs.aspx"
                                        linkstr_txt = Me._cut_txt + " - Diamonds Pairs"


                                End Select
                        End Select
                    Case 2 '' fency
                        Select Case Me._plate_subcat
                            Case 6 ''loose
                                linkstr_txt = Me._cut_txt + " - Fancy Diamonds"
                                linkstr = "/listitem.aspx?mode=1&st=Fancy%20Diamond&sh=" + Me._cut + "%20Cut&r2=0"
                            Case 7 ''pars
                                Select Case Me._cut_txt
                                    'Case "Half Moon shape"
                                    '    linkstr = "/diamonds/diamond-halfmoon-pairs.aspx"
                                    '    linkstr_txt = Me._cut_txt + " - Diamonds Pairs"
                                Case "Heart shape"
                                        linkstr = "/diamonds/fancy-diamond-heart-pairs.aspx"
                                        linkstr_txt = Me._cut_txt + " - Diamonds Pairs"
                                    Case "Oval Cut"
                                        linkstr = "/diamonds/fancy-diamond-oval-pairs.aspx"
                                        linkstr_txt = Me._cut_txt + " - Diamonds Pairs"
                                    Case "Pear Cut"
                                        linkstr = "/diamonds/fancy-diamond-pear-pairs.aspx"
                                        linkstr_txt = Me._cut_txt + " - Diamonds Pairs"
                                    Case "Round bralliant Cut"
                                        linkstr = "/diamonds/fancy-diamond-round-brilliant-pairs.aspx"
                                        linkstr_txt = Me._cut_txt + " - Diamonds Pairs"
                                    Case "Trillion Cut"
                                        linkstr = "/diamonds/fancy-diamond-trillion-pairs.aspx"
                                        linkstr_txt = Me._cut_txt + " - Diamonds Pairs"
                                End Select

                        End Select
                End Select
                '/listitem.aspx?mode=2&st=Ruby&sh=Emerald%20Cut&r2=0
            Case 2 '' gems
                Select Case Me._plate_cat
                    Case 3 ''ruby
                        Select Case Me._plate_subcat
                            Case 11 ''loose
                                linkstr_txt = Me._cut_txt + " - Rubies"
                                linkstr = "/listitem.aspx?mode=2&st=Ruby&sh=" + Me._cut + "&r2=0"

                            Case 12 ''pars
                                Select Case Me._cut_txt
                                    'Case "Half Moon shape"
                                    '    linkstr = "/diamonds/diamond-halfmoon-pairs.aspx"
                                    '    linkstr_txt = Me._cut_txt + " - Diamonds Pairs"
                                    'Case "Heart shape"
                                    '    linkstr = "/diamonds/fancy-diamond-heart-pairs.aspx"
                                    '    linkstr_txt = Me._cut_txt + " - Diamonds Pairs"
                                Case "Oval Cut"
                                        linkstr = "/gem-stones/rubies-oval-pairs.aspx"
                                        linkstr_txt = Me._cut_txt + " - Ruby Pairs"
                                    Case "Pear Cut"
                                        linkstr = "/gem-stones/rubies-pear-pairs.aspx"
                                        linkstr_txt = Me._cut_txt + " - Ruby Pairs"
                                    Case "Round Cut"
                                        linkstr = "/gem-stones/rubies-round-pairs.aspx"
                                        linkstr_txt = Me._cut_txt + " - Ruby Pairs"
                                        'Case "Trillion Cut"
                                        '    linkstr = "/diamonds/fancy-diamond-trillion-pairs.aspx"
                                        '    linkstr_txt = Me._cut_txt + " - Diamonds Pairs"
                                    Case "Emerald Cut"
                                        linkstr = "/gem-stones/rubies-emerald-pairs.aspx"
                                        linkstr_txt = Me._cut_txt + " - Ruby Pairs"
                                End Select


                        End Select
                    Case 4 'sapphire
                        Select Case Me._plate_subcat
                            Case 16 ''loose
                                linkstr_txt = Me._cut_txt + " - Sapphires"
                                linkstr = "/listitem.aspx?mode=2&st=sapphire&sh=" + Me._cut + "&r2=0"
                            Case 17 ''pars
                                linkstr = "/gem-stones/sapphires-pairs.aspx"
                                linkstr_txt = "Sapphire Pairs"
                                'Select Case Me._cut_txt
                                '    'Case "Half Moon shape"
                                '    '    linkstr = "/diamonds/diamond-halfmoon-pairs.aspx"
                                '    '    linkstr_txt = Me._cut_txt + " - Diamonds Pairs"
                                '    'Case "Heart shape"
                                '    '    linkstr = "/diamonds/fancy-diamond-heart-pairs.aspx"
                                '    '    linkstr_txt = Me._cut_txt + " - Diamonds Pairs"
                                'Case "Oval Cut"
                                '        linkstr = "/gem-stones/sapphires-oval-pairs.aspx"
                                '        linkstr_txt = Me._cut_txt + " - Sapphire Pairs"
                                '    Case "Pear Cut"
                                '        linkstr = "/gem-stones/sapphires-pear-pairs.aspx"
                                '        linkstr_txt = Me._cut_txt + " - Sapphire Pairs"
                                '    Case "Round Cut"
                                '        linkstr = "/gem-stones/sapphires-round-pairs.aspx"
                                '        linkstr_txt = Me._cut_txt + " - Sapphire Pairs"
                                '        'Case "Trillion Cut"
                                '        '    linkstr = "/diamonds/fancy-diamond-trillion-pairs.aspx"
                                '        '    linkstr_txt = Me._cut_txt + " - Diamonds Pairs"
                                '    Case "Emerald Cut"
                                '        linkstr = "/gem-stones/sapphires-emerald-pairs.aspx"
                                '        linkstr_txt = Me._cut_txt + " - Sapphire Pairs"

                                'End Select
                        End Select
                    Case 5 'emerals
                        Select Case Me._plate_subcat
                            Case 21 ''loose
                                linkstr_txt = Me._cut_txt + " - Emeralds"
                                linkstr = "/listitem.aspx?mode=2&st=Emerald&sh=" + Me._cut + "&r2=0"
                            Case 22 ''pars
                                Select Case Me._cut_txt
                                    'Case "Half Moon shape"
                                    '    linkstr = "/diamonds/diamond-halfmoon-pairs.aspx"
                                    '    linkstr_txt = Me._cut_txt + " - Diamonds Pairs"
                                    'Case "Heart shape"
                                    '    linkstr = "/diamonds/fancy-diamond-heart-pairs.aspx"
                                    '    linkstr_txt = Me._cut_txt + " - Diamonds Pairs"
                                Case "Oval Cut"
                                        linkstr = "/gem-stones/emeralds-oval-pairs.aspx"
                                        linkstr_txt = Me._cut_txt + " - Emerald Pairs"
                                    Case "Pear Cut"
                                        linkstr = "/gem-stones/emeralds-pear-pairs.aspx"
                                        linkstr_txt = Me._cut_txt + " - Emerald Pairs"
                                    Case "Round Cut"
                                        linkstr = "/gem-stones/emeralds-round-pairs.aspx"
                                        linkstr_txt = Me._cut_txt + " - Emerald Pairs"
                                    Case "Emerald Cut"
                                        linkstr = "/gem-stones/emeralds-emerald-pairs.aspx"
                                        linkstr_txt = Me._cut_txt + " - Emerald Pairs"
                                        'Case "Trillion Cut"
                                        '    linkstr = "/diamonds/fancy-diamond-trillion-pairs.aspx"
                                        '    linkstr_txt = Me._cut_txt + " - Diamonds Pairs"

                                End Select
                        End Select
                    Case 6 'semi
                        Select Case Me._plate_subcat
                            Case 26 ''loose
                                linkstr_txt = "More Semi Precious"
                                linkstr = "/gam-stones/semi-precious-loose.aspx"
                            Case 27 ''pars
                                linkstr_txt = "More Semi Precious Pairs"
                                linkstr = "/gam-stones/semi-precious-pairs.aspx"

                        End Select
                End Select
            Case 3 ''jewel
                Select Case Me._plate_subcat
                    Case 31 ''rings
                        linkstr_txt = "Rings With " + Me._middlestone + "<br>Center Stone"
                        linkstr = "/listitem.aspx?mode=3&jc=Ring&ms=" + Me._middlestone + "&r2=0"
                    Case 32 '' earings
                        linkstr_txt = "Earrings With " + Me._middlestone + "<br>Center Stone"
                        linkstr = "/listitem.aspx?mode=3&jc=Earrings&ms=" + Me._middlestone + "&r2=0"
                    Case 33
                        linkstr_txt = "Nacklaces With " + Me._middlestone + "<br>Middle Stone"
                        linkstr = "/listitem.aspx?mode=3&jc=Necklace&ms=" + Me._middlestone + "&r2=0"
                    Case 36
                        linkstr_txt = "Broaches With " + Me._middlestone + "<br>Center Stone"
                        linkstr = "/listitem.aspx?mode=3&jc=Broach&ms=" + Me._middlestone + "&r2=0"
                    Case 34
                        linkstr_txt = "Pendants With " + Me._middlestone + "<br>Center Stone"
                        linkstr = "/listitem.aspx?mode=3&jc=Pendant&ms=" + Me._middlestone + "&r2=0"
                        ''Case 36
                        ''  linkstr = "/listitem.aspx?mode=3&jc=Watch&ms=" + Me._middlestone + "&r2=0"
                    Case 44 ''mountings 
                        Select Case Me._mounttype
                            Case "Solitair Ring Mountings"
                                linkstr_txt = "More Solitare Rings Mountings"
                                linkstr = "/jewelry/jewelry-settings-rings-solitair.aspx"
                            Case "Three stone Ring Mountings"
                                linkstr_txt = "More Three stone Ring Mountings"
                                linkstr = "/jewelry/jewelry-settings-rings-three-stone.aspx"
                            Case "Three stone Ring Mountings with Diamond side stones"
                                linkstr_txt = "More Three stone Ring Mountings"
                                linkstr = "/jewelry/jewelry-settings-rings-three-stone.aspx"
                            Case "Multi stone Ring Mountings"
                                linkstr_txt = "More Multi stone Ring Mountings"
                                linkstr = "/jewelry/jewelry-settings-rings-multi-stone.aspx"

                        End Select

                End Select
        End Select

       '' Dim testa As String = "<a href='" + HttpContext.Current.Session("user")._domain + "/feedbacks.aspx?id=" + Convert.ToString(Me._id) + "' > Read related testimonials</a>"
        If linkstr <> "" Then
            outstring = outstring + "<center><a href=" + HttpContext.Current.Session("user")._domain + linkstr + "><font color=black><br><BIG><B>" + linkstr_txt + "</B></BIG><BR>click Here</a></b></font></center>"
        End If
        Return True
    End Function


End Class
