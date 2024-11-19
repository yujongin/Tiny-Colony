# Tiny-Colony

### 3일 게임 제작 프로젝트
#### (11/01, 11/04 ~ 11/05)

### [Play 링크](https://yujongin.github.io/Tiny-Colony-Play/)

##### 모바일은 지원하지 않습니다. PC Web에서 실행해주세요.

### Tiny Colony라는 기존에 있는 게임을 모작해보았습니다. <br/>
![image](https://github.com/user-attachments/assets/42a04ed5-c6ed-460c-bc64-c88b992683d3)


[원본 게임 링크](https://mreliptik.itch.io/tiny-colony) 
<br/><br/><br/><br/>

## 기획 의도
<br/>
<img src="https://github.com/user-attachments/assets/589a0db4-4bac-4ff6-89eb-2faaa5f2a820" width="640" height="360"/>

### 개략적인 게임 플레이 & 게임의 목표

#### 1. 슬링 샷으로 작은 사람들을 날려 행성의 정류장에 일정 사람 수 이상으로 도착하게 만들면 클리어
#### 2. 행성에 지형지물을 심어 조경 점수를 추가로 획득
#### 3. 폭탄으로 이동 경로에 방해되는 장애물 제거
<br/>
<img src="https://github.com/user-attachments/assets/cafbb502-3a17-406e-ac84-895f366a39eb" width="640" height="360"/>

### 기획 수정 의도

#### 1. 만드려는 게임을 찾던 중 tiny colony라는 게임을 찾게 돼서 해보았고 재밌지만 추가적인 요소가 들어있으면 좋겠다는 생각을 했습니다
#### 2. 기존 게임에서는 사람외의 다른 오브젝트도 던질 수 있게 해놓았는데 별다른 기능이 추가되어 있지는 않았습니다. <br/> 그래서 오브젝트에 의미를 조금 더 부여하여 재미 요소를 추가하였습니다

<br/><br/><br/>
## 게임 플레이
<br/>
<img src="https://github.com/user-attachments/assets/738d5f19-00c4-46d8-a55d-9e9d9ad0fdca" width="640" height="360"/>

### 게임 플레이의 핵심 메커니즘
<br/>

#### 게임의 목표
  - #### 장애물을 피해 새로운 행성으로 사람들을 날려보내 정류장에 안전하게 도착하도록 하면 승리합니다
<br/>

#### 게임의 규칙
  - #### 날릴 수 있는 사람의 수는 제한되어 있습니다
  - #### 행성에는 행성의 중심으로부터 주변에 그려진 원 범위 안쪽으로 중력이 작용합니다.
  - #### 행성에 집, 나무, 발전소 등을 올바르게 안착시키면 추가 환경점수를 획득합니다.
  - #### 하지만 원자력 발전소의 경우 다른 오브젝트들과 부딪히게 되면 그 오브젝트를 삭제시키고 폭탄과 부딪히게 되면 폭발합니다.
  - #### 만약 정류장에 정해진 사람만큼 도착하지 못하면 실패입니다.
<br/>

#### 조작 방법
  - #### 플레이 화면 아래에 패널에서 원하는 오브젝트를 선택해 슬링 샷에 장전합니다.
  - #### 좌클릭으로 장전, 우클릭으로 장전 해제를 할 수 있습니다.
  - #### 마우스로 슬링 샷을 당겨 오브젝트를 행성을 향해 발사합니다.
<br/>

<img src="https://github.com/user-attachments/assets/6d068b04-36e5-493d-bf84-c7b64e1fa41e" width="640" height="360"/>

#### 진행 방법
  - #### 각 stage가 있고 원하는 스테이지를 선택해 진행할 수 있습니다.
  - #### 스테이지를 클리어하면 별점을 통해 최고 기록이 저장됩니다.

<br/><br/><br/>
## 구현한 주요기능

 - #### 사람을 날리는 슬링샷
![image](https://github.com/user-attachments/assets/09118187-92be-4fac-a370-59fb5e41405a)
 - #### 행성을 향하는 중력
![image](https://github.com/user-attachments/assets/650bdb80-d15f-4922-8a73-19a244e7c251)
 - #### 행성에 폭탄이 떨어졌을 때 행성이 깎이는 효과
![image](https://github.com/user-attachments/assets/cbd2d616-e0ab-4f91-bd6e-6fcabb8ef58b)
 - #### 소행성 또는 장애물이 폭탄에 맞아 없어지거나 오브젝트에 피해를 주는 효과
![image](https://github.com/user-attachments/assets/f352bf3d-4be0-4792-8deb-172e4c98dc0b)









