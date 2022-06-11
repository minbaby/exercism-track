using System;

// TODO: define the 'AccountType' enum
enum AccountType
{

    Guest,
    User,
    Moderator,
}

// TODO: define the 'Permission' enum
[Flags] // 按位标识
enum Permission
{
    None = 0,
    Read = 1 << 0, // 0001
    Write = 1 << 1, // 0010
    Delete = 1 << 2, // 0100
    All = Read | Write | Delete, // 0111
}

static class Permissions
{
    public static Permission Default(AccountType accountType)
    {
        return accountType switch
        {
            AccountType.Guest => Permission.Read,
            AccountType.User => Permission.Read | Permission.Write,
            AccountType.Moderator => Permission.All,
            _ => Permission.None,
        };
    }

    public static Permission Grant(Permission current, Permission grant)
    {
        return current | grant;
    }

    // 这个可以有移除不存在的权限的操作， 这种操作肯定不是最简方法，一会去看看别人是怎么写的
    // 000011
    // 000111
    public static Permission Revoke1(Permission current, Permission revoke)
    {
        if (Check(revoke, Permission.Read) && Check(current, Permission.Read))
        {
            current = current ^ Permission.Read;
        }

        if (Check(revoke, Permission.Write) && Check(current, Permission.Write))
        {
            current = current ^ Permission.Write;
        }

        if (Check(revoke, Permission.Delete) && Check(current, Permission.Delete))
        {
            current = current ^ Permission.Delete;
        }

        return current;
    }

    // 000011
    // 000111 => 取反 => 111000
    public static Permission Revoke(Permission current, Permission revoke)
    {
        return current & ~revoke;
    }

    public static bool Check1(Permission current, Permission check)
    {
        bool ret = false;

        if ((check & Permission.Read) == Permission.Read)
        {
            ret = (current & Permission.Read) == Permission.Read;
            if (!ret)
            {
                return ret;
            }
        }

        if ((check & Permission.Write) == Permission.Write)
        {
            ret = (current & Permission.Write) == Permission.Write;
            if (!ret)
            {
                return ret;
            }
        }

        if ((check & Permission.Delete) == Permission.Delete)
        {
            ret = (current & Permission.Delete) == Permission.Delete;
            if (!ret)
            {
                return ret;
            }
        }

        return ret;
    }

    public static bool Check(Permission current, Permission check)
    {
        return current.HasFlag(check);
    }
}
