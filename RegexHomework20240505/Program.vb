Imports System
Imports System.Text.RegularExpressions

Module Program
    Sub Main(args As String())
        '1.1 電話番号を表す正規表現パターン
        '10～11桁の数字とハイフンで構成される
        'ハイフンを含んでもよいが、数字のみでも可
        Console.WriteLine("電話番号を入力して下さい")
        '入力された電話番号を変数に格納
        Dim input As String = Console.ReadLine()

        '電話番号パターンを抽出するための正規表現
        Dim PHONENUMBER As String = "^(^0[0-9]{9,10}|^0\d{1,3}-\d{3,4}-\d{3,4})$"
        '入力された電話番号とマッチするかを確認
        Dim mtc As MatchCollection = Regex.Matches(input, PHONENUMBER)

        'MatchCollectionオブジェクトが空でないかチェックする
        If mtc.Count > 0 Then
            Dim mach As Match = mtc(0)
            Console.WriteLine(mach.Value & "は、電話番号にマッチしました")
        Else
            Console.WriteLine("電話番号にマッチしませんでした")
        End If

        '改行
        Console.WriteLine()

        '1.2 Windowsのファイルパスを表す正規表現パターン
        'ファイルパスの例：C:\media\image\sample.jpg
        'ドライブレターはAからZまで
        'フォルダ名、ファイル名、拡張子は英数字のみ
        'ファイルの拡張子は文字数に制限なく、拡張子がない場合もある
        Console.WriteLine("ファイルパスを入力して下さい")
        '入力されたパスを変数に格納
        Dim file As String = Console.ReadLine()
        'ファイルパスのパターンを抽出する正規表現
        'バックスラッシュと.はエスケープさせる
        'ドライブ直下の場合はファイルパスはない
        Dim FILEPATH As String = "^[A-Z]:\\([a-zA-Z0-9]*\\)*[a-zA-Z0-9]*(\.[a-zA-Z0-9]*)?$"
        '入力されたパスが指定したファイルパスのパターンにマッチするか確認
        Dim pmtc As MatchCollection = Regex.Matches(file, FILEPATH)

        'マッチする場合は1回のみである為、インデックス0のMachオブジェクトを抽出する
        Try
            Dim pmach As Match = pmtc(0)
            If Not String.IsNullOrEmpty(pmach.Groups(0).Value) Then
                Console.WriteLine("あなたが入力したファイルパス" & vbCrLf &
                                  "{0}はパターンにマッチしました。", pmach)
            End If
        Catch ex As Exception
            'マッチしなかった場合は例外が発生する為、エラーを表示する
            Console.WriteLine("入力されたファイルパスがパス条件にマッチしません。" & vbCrLf &
                              "パスを確認してください")
        End Try


    End Sub
End Module
