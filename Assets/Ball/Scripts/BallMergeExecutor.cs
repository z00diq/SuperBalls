using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;


public class BallMergeExecutor
{
    private static BallMergeExecutor _instance;

    List<IntersectableBallsTuple> _ballsInMerging = new List<IntersectableBallsTuple>();

    public static BallMergeExecutor CreateMerging()
    {
        if (_instance != null)
            return _instance;

        return _instance=new BallMergeExecutor();
    }

    public async Task StartMerging(Ball fromBall, Ball toBall)
    {
        await MergeBalls(fromBall, toBall);
    }

    private async Task MergeBalls(Ball fromBall, Ball toBall)
    {
        IntersectableBallsTuple newParams = new IntersectableBallsTuple(fromBall, toBall);

        if (_ballsInMerging.Where(item=> IntersectableBallsTuple.Intersect(item,newParams)).Count()!=0)
            return;
        
        _ballsInMerging.Add(newParams);
        fromBall.BecomeKinematic();

        while (fromBall.transform.position != toBall.transform.position)
        {
            fromBall.transform.position = Vector3.MoveTowards(fromBall.transform.position,
                toBall.transform.position, Time.deltaTime * 5f);
            await Task.Yield();
        }

        _ballsInMerging.Remove(newParams);
        fromBall.Destroy();
        toBall.LevelUp();
    }

    class IntersectableBallsTuple : System.Tuple<Ball, Ball>
    {
        public IntersectableBallsTuple(Ball item1, Ball item2) : base(item1, item2)
        {
        }

        public static bool Intersect(IntersectableBallsTuple first,IntersectableBallsTuple second)
        {
            if (first.Item1 == second.Item1 || first.Item1 == second.Item2)
                return true;

            if (first.Item2 == second.Item1 || first.Item2 == second.Item2)
                return true;

            return false;
        }
    }
}
