/*
 * @lc app=leetcode.cn id=355 lang=csharp
 *
 * [355] 设计推特
 */

// @lc code=start

public class Tweet
{
    int id;
    string content;
    int order;

    public int ID
    {
        get {return id;}
    }
    public string CONTENT
    {
        get {return content;}
    }
    public int ORDER
    {
        get {return order;}
    }
    public Tweet(int tweetID, string tweetContent, int tweetOrder)
    {
        this.id = tweetID;
        this.content = tweetContent;
        this.order = tweetOrder;
    }
}

public class User
{
    int id;
    HashSet<User> following;
    List<Tweet> myTweets;

    public int ID {
        get {return id;}
    }
    public List<Tweet> UserTweets
    {
        get {return myTweets;}
    }

    public User(int userID)
    {
        this.id = userID;
        following = new HashSet<User>(){this};  // contains oneself
        myTweets = new List<Tweet>();
    }
    public void postNewTweet (int tweetID, int tweetOrder)
    {
        Tweet newTweet = new Tweet(tweetID, "", tweetOrder);
        myTweets.Add(newTweet);
    }
    public void follow (User followee)
    {
        if (!following.Contains(followee))
            following.Add(followee);
    }
    public void unfollow (User followee)
    {
        if (following.Contains(followee))
        {
            // cannot remove oneself
            if (this != followee)
                following.Remove(followee);
        }
    }
    public Dictionary<int, int> getTweets()
    {
        Dictionary<int, int> ans = new Dictionary<int, int>();
        foreach (User u in following)
        {
            foreach (Tweet t in u.UserTweets)
                ans.Add(t.ORDER, t.ID);
        }
        return ans;
    }
}

public class Twitter {
    int tweetCnt = 0;
    Dictionary<int, User> allUsers;

    /** Initialize your data structure here. */
    public Twitter() {
        allUsers = new Dictionary<int, User>();
    }
    
    /** Compose a new tweet. */
    public void PostTweet(int userId, int tweetId) {
        User poster = FindOrCreateUserById(userId);
        poster.postNewTweet(tweetId, tweetCnt);
        tweetCnt++;
    }
    
    /** Retrieve the 10 most recent tweet ids in the user's news feed. Each item in the news feed must be posted by users who the user followed or by the user herself. Tweets must be ordered from most recent to least recent. */
    public IList<int> GetNewsFeed(int userId) {
        User user = FindOrCreateUserById(userId);
        Dictionary<int, int> tweets = user.getTweets();
        //displayDictionary(tweets);
        List<int> sortedDictKeys = tweets.Keys.OrderByDescending(i=>i).ToList();

        List<int> ans = new List<int>();
        foreach (int key in sortedDictKeys)
        {
            ans.Add(tweets[key]);
            if (ans.Count==10) break;
        }
        return ans;
    }
    
    /** Follower follows a followee. If the operation is invalid, it should be a no-op. */
    public void Follow(int followerId, int followeeId) {
        User follower = FindOrCreateUserById(followerId);
        User followee = FindOrCreateUserById(followeeId);
        follower.follow(followee);
    }
    
    /** Follower unfollows a followee. If the operation is invalid, it should be a no-op. */
    public void Unfollow(int followerId, int followeeId) {
        User follower = FindOrCreateUserById(followerId);
        User followee = FindOrCreateUserById(followeeId);
        follower.unfollow(followee);
    }

    private User FindOrCreateUserById(int id)
    {
        if (!allUsers.ContainsKey(id))
            allUsers.Add(id, new User(id));
        return allUsers[id];
    }

    private void displayDictionary<T>(Dictionary<T, T> dict)
    {
        string s = "";
        foreach (KeyValuePair<T,T> kvp in dict)
        {
			s += string.Format("[{0}:{1}],", kvp.Key, kvp.Value);
        }
        Console.WriteLine(s.TrimEnd(','));
    }
}

/**
 * Your Twitter object will be instantiated and called as such:
 * Twitter obj = new Twitter();
 * obj.PostTweet(userId,tweetId);
 * IList<int> param_2 = obj.GetNewsFeed(userId);
 * obj.Follow(followerId,followeeId);
 * obj.Unfollow(followerId,followeeId);
 */
// @lc code=end

