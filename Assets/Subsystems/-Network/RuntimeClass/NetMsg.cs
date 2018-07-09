using System.Collections;
using System.Collections.Generic;

public class NetMsg<T> : NetBaseMsg
{
    public T ret;
    public List<XTransaction> xcache;
}

