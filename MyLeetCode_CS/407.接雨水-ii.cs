/*
 * @lc app=leetcode.cn id=407 lang=csharp
 *
 * [407] 接雨水 II
 */

// @lc code=start

public class Point
{
    public int x,y,h;
    public Point(int x, int y, int h)
    {
        this.x = x;
        this.y = y;
        this.h = h;
    }
}

public class PriorityQueue
{
	private List<Point> data;

	public PriorityQueue() {
		this.data = new List<Point>();
	}

	public void Enqueue(Point item) {
		data.Add(item);
		int ci = data.Count - 1; // child index; start at end
		while (ci > 0) {
			int pi = (ci - 1) / 2; // parent index
            if (data[ci].h >= data[pi].h)
				break; // child item is larger than (or equal) parent so we're done
			Point tmp = data[ci];
			data[ci] = data[pi];
			data[pi] = tmp;
			ci = pi;
		}
	}

	public Point Dequeue() {
		// assumes pq is not empty; up to calling code
		int li = data.Count - 1; // last index (before removal)
		Point frontItem = data[0];   // fetch the front
		data[0] = data[li];
		data.RemoveAt(li);

		--li; // last index (after removal)
		int pi = 0; // parent index. start at front of pq
		while (true) {
			int ci = pi * 2 + 1; // left child index of parent
			if (ci > li)
				break;  // no children so done
			int rc = ci + 1;     // right child
            
            if (rc <= li && data[rc].h < data[ci].h)
                ci = rc;    // if there is a rc (ci + 1), and it is smaller than left child, use the rc instead
            if (data[pi].h <= data[ci].h)
				break;      // parent is smaller than (or equal to) smallest child so done
			Point tmp = data[pi];
			data[pi] = data[ci];
			data[ci] = tmp; // swap parent and child
			pi = ci;
		}
		return frontItem;
	}

	public Point Peek() 
    {
		return data[0];
	}

	public int Count() 
    {
		return data.Count;
	}

	public override string ToString() {
		string s = "";
		for (int i = 0; i < data.Count; ++i)
            s += string.Format("[{0}, {1}, {2}], ", data[i].x, data[i].y, data[i].h);
        s = string.Format("count={0}: {1}", data.Count, s);
		return s;
	}

	public bool IsConsistent() {
		// is the heap property true for all data?
		if (data.Count == 0)
			return true;
		int li = data.Count - 1; // last index
		for (int pi = 0; pi < data.Count; ++pi) { // each parent index
			int lci = 2 * pi + 1; // left child index
			int rci = 2 * pi + 2; // right child index

			if (lci <= li && data[pi].h > data[lci].h)
				return false; // if lc exists and it's greater than parent then bad.
			if (rci <= li && data[pi].h > data[rci].h)
				return false; // check the right child too.
		}
		return true; // passed all checks
	}
	// IsConsistent
}

public class Solution {
    public int TrapRainWater(int[][] heightMap) 
    {
        int vol=0;

        // validate input
        int m = heightMap.Length;
        if (m==0) return vol;
        int n = heightMap[0].Length;
        if (n==0) return vol;

        PriorityQueue queue = new PriorityQueue();
        bool[,] visited = new bool[m,n];

        // Enqueue the surrounding cells        
        for (int i=0;i<m;i++)
        {
            // first column
            queue.Enqueue(new Point(i,0, heightMap[i][0]));
            visited[i, 0] = true;
            // last column
            queue.Enqueue(new Point(i,n-1, heightMap[i][n-1]));
            visited[i, n-1] = true;
        }
        for (int j=1; j<n-1; j++)
        {
            // first row
            queue.Enqueue(new Point(0,j, heightMap[0][j]));
            visited[0, j] = true;
            // last column
            queue.Enqueue(new Point(m-1,j, heightMap[m-1][j]));
            visited[m-1, j] = true;
        }

        // Console.WriteLine(queue.ToString());

        // BFS
        int tmpX, tmpY, tmpH;
        while (queue.Count() > 0)
        {
            Point currPt = queue.Dequeue();
            // Console.Write("Popped: [{0},{1},{2}], Pushed: ", currPt.x, currPt.y, currPt.h);

            // check left
            tmpX = currPt.x;
            tmpY = currPt.y-1;
            if (tmpY>=0 && !visited[tmpX, tmpY])
            {
                tmpH = heightMap[tmpX][tmpY];
                if (tmpH < currPt.h)
                {
                    vol += currPt.h - tmpH;
                    tmpH = currPt.h;
                }
                queue.Enqueue(new Point(tmpX, tmpY, tmpH));
                // Console.Write("[{0},{1},{2}]", tmpX, tmpY, tmpH);
                visited[tmpX, tmpY] = true;
            }
            // check right
            tmpX = currPt.x;
            tmpY = currPt.y+1;
            if (tmpY<n && !visited[tmpX, tmpY])
            {
                tmpH = heightMap[tmpX][tmpY];
                if (tmpH < currPt.h)
                {
                    vol += currPt.h - tmpH;
                    tmpH = currPt.h;
                }
                queue.Enqueue(new Point(tmpX, tmpY, tmpH));
                // Console.Write("[{0},{1},{2}]", tmpX, tmpY, tmpH);
                visited[tmpX, tmpY] = true;
            }
            // check up
            tmpX = currPt.x-1;
            tmpY = currPt.y;
            if (tmpX>=0 && !visited[tmpX, tmpY])
            {
                tmpH = heightMap[tmpX][tmpY];
                if (tmpH < currPt.h)
                {
                    vol += currPt.h - tmpH;
                    tmpH = currPt.h;
                }
                queue.Enqueue(new Point(tmpX, tmpY, tmpH));
                // Console.Write("[{0},{1},{2}]", tmpX, tmpY, tmpH);
                visited[tmpX, tmpY] = true;
            }
            // check down
            tmpX = currPt.x+1;
            tmpY = currPt.y;
            if (tmpX<m && !visited[tmpX, tmpY])
            {
                tmpH = heightMap[tmpX][tmpY];
                if (tmpH < currPt.h)
                {
                    vol += currPt.h - tmpH;
                    tmpH = currPt.h;
                }
                queue.Enqueue(new Point(tmpX, tmpY, tmpH));
                // Console.Write("[{0},{1},{2}]", tmpX, tmpY, tmpH);
                visited[tmpX, tmpY] = true;
            }
            // Console.WriteLine();
        }
        return vol;
    }

}
// @lc code=end

