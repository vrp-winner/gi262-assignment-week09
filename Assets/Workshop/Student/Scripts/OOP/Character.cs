using UnityEngine;


namespace Solution
{
    public class Character : Identity
    {
        [Header("Character")]
        public int energy;
        public int maxEnergy;
        public int AttackPoint;

        protected bool isAlive;
        protected bool isFreeze;

        public SpriteRenderer spriteRenderer; // ลาก SpriteRenderer ของตัวละครมาใส่ใน Inspector

        // สีที่เราจะใช้ 3 ระดับ
        [Header("color energy")]
        public Color normalColor = Color.white;    // สีปกติ
        public Color damagedColor1 = Color.yellow; // ได้รับความเสียหายระดับ 1 (เช่น HP เหลือ 66%)
        public Color damagedColor2 = Color.red;    // ได้รับความเสียหายระดับ 2 (เช่น HP เหลือ 33%)

        public override void SetUP()
        {
            isAlive = true;
            isFreeze = false;
            Debug.Log("SetUP " + Name);
            spriteRenderer = GetComponent<SpriteRenderer>();
            energy = maxEnergy;

            UpdateSpriteColorBasedOnHealth(); // เริ่มต้นด้วยการตั้งค่าสีตามพลังชีวิตปัจจุบัน
        }
        protected void GetRemainEnergy()
        {
            Debug.Log(name + " : " + energy);
        }

        public virtual void Move(Vector2 direction)
        {
            if (isFreeze == true)
            {
                GetComponent<SpriteRenderer>().color = Color.white;
                isFreeze = false;
                return;
            }
            int toX = (int)(positionX + direction.x);
            int toY = (int)(positionY + direction.y);

            if (HasPlacement(toX, toY))
            {
                bool isCanWalkTo = mapGenerator.GetMapData(toX,toY).Hit();
                if (isCanWalkTo)
                {
                    UpdatePosition(toX, toY);
                }

            }
            else
            {
                UpdatePosition(toX, toY);
                TakeDamage(1);
            }

        }

        public virtual void UpdatePosition(int toX, int toY)
        {
            mapGenerator.mapdata[positionX, positionY] = null;
            positionX = toX;
            positionY = toY;
            transform.position = new Vector3(positionX, positionY, 0);
            mapGenerator.mapdata[positionX, positionY] = this;
        }

        // hasPlacement คืนค่า true ถ้ามีการวางอะไรไว้บน map ที่ตำแหน่ง x,y
        public bool HasPlacement(int x, int y)
        {
            var mapData = mapGenerator.GetMapData(x, y);
            return mapData != null;
        }
      

        public virtual void TakeDamage(int Damage)
        {
            energy -= Damage;
            Debug.Log(name + " Current Energy : " + energy);
            UpdateSpriteColorBasedOnHealth();
            CheckDead();
        }
        public virtual void TakeDamage(int Damage, bool freeze)
        {
            energy -= Damage;
            isFreeze = freeze;
            GetComponent<SpriteRenderer>().color = Color.blue;
            Debug.Log(name + " Current Energy : " + energy);
            Debug.Log("you is Freeze");
            UpdateSpriteColorBasedOnHealth();
            CheckDead();
        }


        public void Heal(int healPoint)
        {
            // energy += healPoint;
            // Debug.Log("Current Energy : " + energy);
            // เราสามารถเรียกใช้ฟังก์ชัน Heal โดยกำหนดให้ Bonuse = false ได้ เพื่อที่จะให้ logic ในการ heal อยู่ที่ฟังก์ชัน Heal อันเดียวและไม่ต้องเขียนซ้ำ
            Heal(healPoint, false);
        }

        public void Heal(int healPoint, bool Bonuse)
        {
            energy += healPoint * (Bonuse ? 2 : 1);
            if (energy > maxEnergy)
            {
                energy = maxEnergy;
            }
            Debug.Log("Current Energy : " + energy);
        }

        protected virtual void CheckDead()
        {
            if (energy <= 0)
            {
                mapGenerator.mapdata[positionX, positionY] = null;
                Destroy(gameObject);
            }
        }
        private void UpdateSpriteColorBasedOnHealth()
        {
            if (spriteRenderer == null) return;

            float healthPercentage = (float)energy / maxEnergy;

            if (healthPercentage > 0.66f) // มากกว่า 66% (เช่น 67%-100%)
            {
                spriteRenderer.color = normalColor;
            }
            else if (healthPercentage > 0.33f) // มากกว่า 33% แต่ไม่เกิน 66% (เช่น 34%-66%)
            {
                spriteRenderer.color = damagedColor1;
            }
            else // 33% หรือน้อยกว่า
            {
                spriteRenderer.color = damagedColor2;
            }
            Debug.Log(name + " Health Percentage: " + (healthPercentage * 100) + "%");
        }
    }
}