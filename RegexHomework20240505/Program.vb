Imports System
Imports System.Text.RegularExpressions

Module Program
    Sub Main(args As String())
        '1.1 �d�b�ԍ���\�����K�\���p�^�[��
        '10�`11���̐����ƃn�C�t���ō\�������
        '�n�C�t�����܂�ł��悢���A�����݂̂ł���
        Console.WriteLine("�d�b�ԍ�����͂��ĉ�����")
        '���͂��ꂽ�d�b�ԍ���ϐ��Ɋi�[
        Dim input As String = Console.ReadLine()

        '�d�b�ԍ��p�^�[���𒊏o���邽�߂̐��K�\��
        Dim PHONENUMBER As String = "^(^0[0-9]{9,10}|^0\d{1,3}-\d{3,4}-\d{3,4})$"
        '���͂��ꂽ�d�b�ԍ��ƃ}�b�`���邩���m�F
        Dim mtc As MatchCollection = Regex.Matches(input, PHONENUMBER)

        'MatchCollection�I�u�W�F�N�g����łȂ����`�F�b�N����
        If mtc.Count > 0 Then
            Dim mach As Match = mtc(0)
            Console.WriteLine(mach.Value & "�́A�d�b�ԍ��Ƀ}�b�`���܂���")
        Else
            Console.WriteLine("�d�b�ԍ��Ƀ}�b�`���܂���ł���")
        End If

        '���s
        Console.WriteLine()

        '1.2 Windows�̃t�@�C���p�X��\�����K�\���p�^�[��
        '�t�@�C���p�X�̗�FC:\media\image\sample.jpg
        '�h���C�u���^�[��A����Z�܂�
        '�t�H���_���A�t�@�C�����A�g���q�͉p�����̂�
        '�t�@�C���̊g���q�͕������ɐ����Ȃ��A�g���q���Ȃ��ꍇ������
        Console.WriteLine("�t�@�C���p�X����͂��ĉ�����")
        '���͂��ꂽ�p�X��ϐ��Ɋi�[
        Dim file As String = Console.ReadLine()
        '�t�@�C���p�X�̃p�^�[���𒊏o���鐳�K�\��
        '�o�b�N�X���b�V����.�̓G�X�P�[�v������
        '�h���C�u�����̏ꍇ�̓t�@�C���p�X�͂Ȃ�
        Dim FILEPATH As String = "^[A-Z]:\\([a-zA-Z0-9]*\\)*[a-zA-Z0-9]*(\.[a-zA-Z0-9]*)?$"
        '���͂��ꂽ�p�X���w�肵���t�@�C���p�X�̃p�^�[���Ƀ}�b�`���邩�m�F
        Dim pmtc As MatchCollection = Regex.Matches(file, FILEPATH)

        '�}�b�`����ꍇ��1��݂̂ł���ׁA�C���f�b�N�X0��Mach�I�u�W�F�N�g�𒊏o����
        Try
            Dim pmach As Match = pmtc(0)
            If Not String.IsNullOrEmpty(pmach.Groups(0).Value) Then
                Console.WriteLine("���Ȃ������͂����t�@�C���p�X" & vbCrLf &
                                  "{0}�̓p�^�[���Ƀ}�b�`���܂����B", pmach)
            End If
        Catch ex As Exception
            '�}�b�`���Ȃ������ꍇ�͗�O����������ׁA�G���[��\������
            Console.WriteLine("���͂��ꂽ�t�@�C���p�X���p�X�����Ƀ}�b�`���܂���B" & vbCrLf &
                              "�p�X���m�F���Ă�������")
        End Try


    End Sub
End Module
