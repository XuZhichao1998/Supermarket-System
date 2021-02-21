using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// PhoneVerification 的摘要说明
/// </summary>
public class PhoneVerification
{
    static public string VerificationCode(string mobile)
    {
        if (IsHandset(mobile))
        {
            string code = new Random().Next(111111, 999999).ToString();
            string content = "[海之星超市]：本次操作的验证码为:" + code + " 切勿泄漏此验证码信息给他人，如非本人操作，请忽略此条信息。";
            // bool ret = SendFast(mobile, content);
            bool ret = true;
            if (ret)
            {
                return code;
            }
            else
            {
                return "发送失败";
            }
        }
        else
        {
            return "手机号码格式不正确";
        }
    }
    static public bool IsHandset(string str)
    {
        return System.Text.RegularExpressions.Regex.IsMatch(str, @"^1[3|4|5|7|8][0-9]\d{8}$"); //^表示从头开始匹配，$匹配\n或\r
    }
}