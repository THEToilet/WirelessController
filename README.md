ping�\��

## �d�l

- �T�[�o���󂯎�����

|���M��| �ʐM�v���� | �ʐM�v���ԍ�  | �o�C�g�� | 10�i�� |
|:---: | :---: | :---: | :---: | :---: |
| client & host_client | pong | 0x01 |
| client & host_client | ���[�U�o�^���N�G�X�g | 0x02 |
| client & host_client | ���[�U�ꗗ�擾���N�G�X�g�i����I�j | 0x03 |
| client | �p�P�b�g���p | 0x04 | 2byte
| client & host_client | �A�v�����E | 0x05 |
| host_client | �R���g���[�����[�U���ϋq�Ȃɑ��� | 0x06
| host_client | ���[�U��BAN���� | 0x07
| host_client | ���[�U���R���g���[���ɓo�^���� | 0x08

- �N���C�A���g���󂯎�����

|���M��| �ʐM�v���� | �ʐM�v���ԍ�  | �o�C�g�� | 10�i�� |
|:---: | :---: | :---: | :---: | :---: |
| server | pong | 0x01 |
| server | �G���[ | 0x02 |
| server | ���[�U�o�^���N�G�X�g | 0x03 |
| server | ���[�U�ꗗ�擾���N�G�X�g�i����I�j | 0x04 |

- �N���C�A���g�z�X�g���󂯎�����

|���M��| �ʐM�v���� | �ʐM�v���ԍ�  | �o�C�g�� | 10�i�� |
| :---: | :---: | :---: | :---: | :---: |
| server | pong | 0x01 |
| server | �G���[ | 0x02 |
| server | ���[�U�o�^���N�G�X�g | 0x03 |
| server | ���[�U�ꗗ�擾���N�G�X�g�i����I�j | 0x04 |
| client | �p�P�b�g���p | 0x05 | 2byte |

�^�C�v + ���[�U�ԍ� + �{�^�� 0x04 + 0x01 + 0x0070

| �{�^�� | 16�i�� | 2�i�� | 10�i�� |
| :---: | :---: | :---: | :---: |
| �� |  0x01 | 0B00000001 | 1 |
| �� | 0x02 | 0B00000010 | 2 |
| �E | 0x04 | 0B00000100 | 4 |
| �� | 0x08 | 0B00001000 | 8 |
| A�{�^�� | 0x10 | 0B00010000 | 16 |
| B�{�^�� | 0x20 | 0B00100000 | 32 |
| 1�{�^�� | 0x40 | 0B01000000  | 64 |
| 2�{�^�� | 0x80 | 0B10000000 | 128 |
| +�{�^�� | 0x0100 | 0B0000000100000000 | 256 |
| -�{�^�� | 0x0200 | 0B0000001000000000 | 512 |
| home�{�^�� | 0x0400 | 0B0000010000000000 | 1024 |
| �V�F�C�N | 0x0800 | 0B0000100000000000 | 2048 |

[ A,B,1 ] : 0x0070 0B0000000001110000

|+�R���g���[���[�ԍ� +�R���g���[���[�^�C�v | host�ڑ��f

| ���[�U�ԍ� | 16�i�� | 2�i�� | 10�i�� |
| :---: | :---: | :---: | :---: |
| 1 | 0x01 | 0B00000001 |
| 2 | 0x02 | 0B00000010 |
| 3 | 0x03 | 0B00000011 |
| 4 | 0x04 | 0B00000100 |

- �p�P�b�g���p
```text
    0                   1                   2                   3
    0 1 2 3 4 5 6 7 8 9 0 1 2 3 4 5 6 7 8 9 0 1 2 3 4 5 6 7 8 9 0 1
   +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
   |      Type     |   Con Number  |            Button             |
   +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
```

```text 
    0                   1                   2                   3
    0 1 2 3 4 5 6 7 8 9 0 1 2 3 4 5 6 7 8 9 0 1 2 3 4 5 6 7 8 9 0 1
   +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
   |      Type     |   Con Number  |            Button             |
   +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
   |         Identification        |Flags|      Fragment Offset    |
   +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
   |  Time to Live |    Protocol   |         Header Checksum       |
   +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
   |                       Source Address                          |
   +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
   |                    Destination Address                        |
   +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
   |                    Options                    |    Padding    |
   +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
```

## �@�\

�N���C�A���g�ڑ��f

- �N���C�A���g�ƃT�[�o�Ԃł�ping-pong���s��

���[�U�}�b�`���O�@�\ �p�P�b�g���p

- ������4������
- �����̓z�X�g1�l�ƎQ����3�l�ō\�������
- �Q���҂�1�l�ȏ�3�l�ȉ�

- 8�l���炢�̃X�y�[�X
- �r���Ńv���C���[�̔ԍ��ς�����
- �v���C���[�̖��O�ǉ�
- �R���g���[���[�^�C�v
- �Œ�2�l
- �Q�[���J�n��̓r���Q��OK

- COM1~4����
- ����4�l���炢�\�������o������
- ���̒������[�ł���
- �Q���҂�8�l
- �v���C����1~4�l�ȊO�͑ҋ@�A�����a�ʊm�F�͂��Ă���
- �N���C�A���g�z�X�g����7�l�̑�����s��
- ����I�Ƀv���C���[�����X�V������5s�Ɉ�񂮂炢
- set com4 to player7
- ���[�U���R���g���[���ɓo�^����
- �㏑��
- ban user
- ���[�U�����S��BAN
- back to queue
- COM����O���ė\���n�ɑ���

### Client -> Server

- �T�[�o�ɓo�^����i���O�ƂƂ��Ɂj
- �R���g���[�����𑗐M����i���������쑤�̏ꍇ�j
- �v���C���[���̍X�V(5s)
- �����𔲂���

### Server -> Client

- �a�ʊm�F
- userID

### Server -> HostClient

- �R���g���[�����𑗂�
- �a�ʊm�F
- userID

### HostClient -> Server

- �T�[�o�ɓo�^
- �R���g���[�����[�U���ϋq�Ȃɑ���
- ���[�U��BAN����
- ���[�U���R���g���[���ɓo�^����
- �v���C���[���̍X�V(5s)
- �����𔲂���

## �ʐM�^�C�v

�ʐM�^�C�v 1byte UUID 16byte