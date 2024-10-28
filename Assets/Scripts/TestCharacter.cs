using Unity.Mathematics;
using UnityEngine;

namespace HHbattle
{
    public class TestCharacter : MonoBehaviour
    {
        private static readonly int s_IsMoving = Animator.StringToHash("IsMoving");

        // 组件
        private Animator _animator;

        #region 变量

        // 移动相关状态变量
        private bool _isMoving = false;
        private bool _isSprint = false;
        private bool _isOnGround = true;
        private bool _isJump = false;

        // 战斗状态变量
        private float _maxHP = 100;
        private float _currentHP = 100;

        #endregion 变量

        #region 常量

        //战斗属性常量


        // 移动相关属性常量
        private const float c_Speed = 3.0f;

        #endregion 常量

        void Start()
        {
            // 获取animator
            _animator = transform.GetComponent<Animator>();
        }

        void Update()
        {
            // 暂时在角色的update种写输入处理代码
            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");
            if (math.abs(x) > 0.001f)
            {
                // 播放移动动画
                _animator.SetBool(s_IsMoving, true);
                if (x > 0)
                {
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                }
                else
                {
                    transform.rotation = Quaternion.Euler(0, 180, 0);
                }

                transform.Translate(Vector2.right * Time.deltaTime * c_Speed);
            }
            else
            {
                // 播放待机动画
                _animator.SetBool(s_IsMoving, false);
            }
        }
    }
}