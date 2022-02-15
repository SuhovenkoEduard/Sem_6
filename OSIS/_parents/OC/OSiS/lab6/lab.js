
let p_t = new Array(10, 3, 3, 7);
let p_ap = new Array(2, 0, 4, 5);
let p_pr = new Array(1, 3, 3, 2);

Array.prototype.sum = function () {
    let result = 0;
    for (const el of this) {
        result += el;
    }
    return result;
}


function FCFS_DIRECT(p_t, p_ap) {
    let p = p_t.slice();
    let workedIndex = -1;
    let proccessQueue = new Array();
    for (let i = 0; p.sum() != 0; i++) {
        for (let j = 0; j < p_ap.length; j++) {
            if (workedIndex >= 0 && p_ap[j] == i)
                proccessQueue.push(j); //добавить в конец
            else if (workedIndex < 0 && p_ap[j] == i && proccessQueue.length == 0)
                workedIndex = j;
            else if (workedIndex < 0 && p_ap[j] == i && proccessQueue.length != 0) {
                proccessQueue.push(j);
                workedIndex = proccessQueue.shift(); //достать из начала
            } else if (workedIndex < 0 && p_ap[j] != i && proccessQueue.length != 0) {
                workedIndex = proccessQueue.shift();
            }
        }
        printLine(formArr(p, p_ap, i), workedIndex);
        if (workedIndex >= 0) {
            p[workedIndex]--;
            if (p[workedIndex] == 0)
                workedIndex = -1;
        }
    }
}

function FCFS_BACK(p_t, p_ap) {
    let p = p_t.slice();
    let workedIndex = -1;
    let proccessStack = new Array();
    for (let i = 0; p.sum() != 0; i++) {
        for (let j = p_ap.length - 1; j >= 0; j--) {
            if (workedIndex >= 0 && p_ap[j] == i)
                proccessStack.push(j);
            else if (workedIndex < 0 && p_ap[j] == i && proccessStack.length == 0)
                workedIndex = j;
            else if (workedIndex < 0 && p_ap[j] == i && proccessStack.length != 0) {
                workedIndex = proccessStack.pop();
                proccessStack.push(j);
            } else if (workedIndex < 0 && p_ap[j] != i && proccessStack.length != 0)
                workedIndex = proccessStack.pop();
        }
        printLine(formArr(p, p_ap, i), workedIndex);
        if (workedIndex >= 0) {
            p[workedIndex]--;
            if (p[workedIndex] == 0)
                workedIndex = -1;
        }
    }
}

function RR(p_t, p_ap) {
    let p = p_t.slice();
    let workedIndex = -1;
    let workedTime = 0;
    let proccessQueue = new Array();
    for (var i = 0; p.sum() != 0; i++) {
        for (var j = 0; j < p_ap.length; j++) {
            if (workedIndex >= 0 && p_ap[j] == i)
                proccessQueue.push(j);
            else if (workedIndex < 0 && p_ap[j] == i && proccessQueue.length == 0) {
                workedIndex = j;
                workedTime = 3;
            } else if (workedIndex < 0 && p_ap[j] == i && proccessQueue.length != 0) {
                proccessQueue.push(j);
                workedIndex = proccessQueue.shift();
                workedTime = 3;
            } else if (workedIndex < 0 && p_ap[j] != i && proccessQueue.length != 0) {
                workedIndex = proccessQueue.shift();
                workedTime = 3;
            }
        }
        printLine(formArr(p, p_ap, i), workedIndex);
        if (workedIndex >= 0) {
            workedTime--;
            p[workedIndex]--;
            if (p[workedIndex] == 0)
                workedIndex = -1;
            else if (workedTime == 0) {
                proccessQueue.push(workedIndex);
                workedIndex = -1;
            }
        }
    }
}
function SFJ_N_N(p_t, p_app)
{
    let p = p_t.slice();
    let workedIndex = -1;
    let proccessList = new Array();
    for (let i = 0; p.sum() != 0; i++)
    {
        for (let j = 0; j < p_ap.length; j++)
        {
            if (workedIndex >= 0 && p_ap[j] == i)
                proccessList.push(FindPosition_NonPriority(p[j], proccessList, p), j);
            else if (workedIndex < 0 && p_ap[j] == i && proccessList.length == 0)
                workedIndex = j;
            else if (workedIndex < 0 && p_ap[j] == i && proccessList.length != 0)
            {
                proccessList.push(FindPosition_NonPriority(p[j], proccessList, p), j);
                workedIndex = proccessList.shift();
            }
            else if (workedIndex < 0 && p_ap[j] != i && proccessList.length != 0)
            {
                workedIndex = proccessList.shift();
            }
        }
        printLine(formArr(p, p_ap, i), workedIndex);
        if (workedIndex >= 0)
        {
            p[workedIndex]--;
            if (p[workedIndex] == 0)
                workedIndex = -1;
        }
    }
}

function SFJ_N_P(p_t, p_app, p_pr)
{
    let p = p_t.slice();
    let workedIndex = -1;
    let proccessList = new Array();
    for (var i = 0; p.sum() != 0; i++)
    {
        for (var j = 0; j < p_ap.Length; j++)
        {
            if (workedIndex >= 0 && p_ap[j] == i)
                proccessList.Insert(FindPosition_Priority(p_pr[j], proccessList, p_pr), j);
            else if (workedIndex < 0 && p_ap[j] == i && proccessList.length == 0)
                workedIndex = j;
            else if (workedIndex < 0 && p_ap[j] == i && proccessList.length != 0)
            {
                proccessList.Insert(FindPosition_Priority(p_pr[j], proccessList, p_pr), j);
                workedIndex = proccessList.First();
                proccessList.RemoveAt(0);
            }
            else if (workedIndex < 0 && p_ap[j] != i && proccessList.length != 0)
            {
                workedIndex = proccessList.First();
                proccessList.RemoveAt(0);
            }
        }
        PrintLine(FormArr(p, p_ap, i), workedIndex);
        if (workedIndex >= 0)
        {
            p[workedIndex]--;
            if (p[workedIndex] == 0)
                workedIndex = -1;
        }
    }
}

function SFJ_N(p_t, p_app)
{
    let p = p_t.slice();
    let workedIndex = -1;
    let proccessList = new Array();
    for (var i = 0; p.sum() != 0; i++)
    {
        for (var j = 0; j < p_ap.Length; j++)
        {
            if (workedIndex >= 0 && p_ap[j] == i)
            {
                proccessList.Insert(FindPosition_NonPriority(p[j], proccessList, p), j);
                proccessList.Insert(FindPosition_NonPriority(p[workedIndex], proccessList, p), workedIndex);
                workedIndex = proccessList.First();
                proccessList.RemoveAt(0);
            }
            else if (workedIndex < 0 && p_ap[j] == i && proccessList.length == 0)
                workedIndex = j;
            else if (workedIndex < 0 && p_ap[j] == i && proccessList.length != 0)
            {
                proccessList.Insert(FindPosition_NonPriority(p[j], proccessList, p), j);
                workedIndex = proccessList.First();
                proccessList.RemoveAt(0);
            }
            else if (workedIndex < 0 && p_ap[j] != i && proccessList.length != 0)
            {
                workedIndex = proccessList.First();
                proccessList.RemoveAt(0);
            }
        }
        PrintLine(FormArr(p, p_ap, i), workedIndex);
        if (workedIndex >= 0)
        {
            p[workedIndex]--;
            if (p[workedIndex] == 0)
                workedIndex = -1;
        }
    }
}

function SFJ_P(p_t, p_app, p_pr)
{
    let p = p_t.slice();
    let workedIndex = -1;
    let proccessList = new Array();
    for (var i = 0; p.sum() != 0; i++)
    {
        for (var j = 0; j < p_ap.Length; j++)
        {
            if (workedIndex >= 0 && p_ap[j] == i)
            {
                proccessList.Insert(FindPosition_Priority(p_pr[j], proccessList, p_pr), j);
                proccessList.Insert(FindPosition_Priority(p_pr[workedIndex], proccessList, p_pr), workedIndex);
                workedIndex = proccessList.First();
                proccessList.RemoveAt(0);
            }
            else if (workedIndex < 0 && p_ap[j] == i && proccessList.length == 0)
                workedIndex = j;
            else if (workedIndex < 0 && p_ap[j] == i && proccessList.length != 0)
            {
                proccessList.Insert(FindPosition_Priority(p_pr[j], proccessList, p_pr), j);
                workedIndex = proccessList.First();
                proccessList.RemoveAt(0);
            }
            else if (workedIndex < 0 && p_ap[j] != i && proccessList.length != 0)
            {
                workedIndex = proccessList.First();
                proccessList.RemoveAt(0);
            }
        }
        PrintLine(FormArr(p, p_ap, i), workedIndex);
        if (workedIndex >= 0)
        {
            p[workedIndex]--;
            if (p[workedIndex] == 0)
                workedIndex = -1;
        }
    }
}


function FindPosition_NonPriority(time, list, p_t)
{
    for (var i = 0; i < list.length; i++)
    {
        if (time < p_t[list[i]])
            return i;
    }
    return list.length;
}
function FindPosition_Priority(prior, list, p_p)
{
    for (var i = 0; i < list.length; i++)
    {
        if (prior <= p_p[list[i]])
            return i;
    }
    return list.length;
}

function printLine(p, procNum) {
    let line = "|";
    for (let i = 0; i < p.length; i++) {
        if (p[i] == 0)
            line += "   |";
        else if (procNum == i)
            line += " И |";
        else
            line += " Г |";
    }
    console.log(line);
    console.log('------------------');
}

function formArr(p, p_ap, time) {
    let result = new Array();
    for (let i = 0; i < p.length; i++) {
        if (p[i] == 0 || time < p_ap[i])
            result.push(0);
        else
            result.push(1);
    }
    return result;
}

console.log('FCFS прямой');
FCFS_DIRECT(p_t, p_ap);
console.log('FCFS обратный');
FCFS_BACK(p_t, p_ap);
console.log('RR');
RR(p_t, p_ap);
console.log('SJF - невытесняющий, без приоритета');
SFJ_N_N(p_t, p_ap);
console.log('SJF - невытесняющий, с приоритетом');
SFJ_N_P(p_t, p_ap, p_pr);
console.log('SJF - вытесняющий, без приоритета');
SFJ_N(p_t, p_ap);
console.log('SJF - вытесняющий, с приоритетом');
SFJ_P(p_ap, p_ap, p_pr);